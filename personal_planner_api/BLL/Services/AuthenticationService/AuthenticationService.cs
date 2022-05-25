using DAL;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<UserModel> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<UserModel> signInManager;
        private readonly IConfiguration configuration;

        public AuthenticationService(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager, SignInManager<UserModel> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public RegistrationResponse Register(RegisterRequest model)
        {
            var userExists = userManager.FindByNameAsync(model.Username).Result;

            if (userExists != null)
            {
                return new RegistrationResponse { Status = "Error", Message = "User already exists!" };
            }

            UserModel user = new UserModel()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = userManager.CreateAsync(user, model.Password).Result;

            if (!roleManager.RoleExistsAsync(UserRoles.User).Result)
                roleManager.CreateAsync(new IdentityRole(UserRoles.User)).Wait();

            if (roleManager.RoleExistsAsync(UserRoles.User).Result)
            {
                userManager.AddToRoleAsync(user, UserRoles.User).Wait();
            }

            if (!result.Succeeded)
            {
                return new RegistrationResponse { Status = "Error", Message = string.Join(" ", result.Errors.Select(e => e.Description).ToList()) };
            }

            return new RegistrationResponse { Status = "Success", Message = "User created successfully!" };
        }
        public LoginResponse Login(LoginRequest model)
        {
            var user = userManager.FindByNameAsync(model.Username).Result;

            if (user == null || !userManager.CheckPasswordAsync(user, model.Password).Result)
            {
                return null;
            }

            var userRoles = userManager.GetRolesAsync(user).Result;

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var newRefreshToken = userManager.GenerateUserTokenAsync(user, "MyApp", "RefreshToken").Result;
            userManager.SetAuthenticationTokenAsync(user, "MyApp", "RefreshToken", newRefreshToken).Wait();

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
                RefreshToken = userManager.GetAuthenticationTokenAsync(user, "MyApp", "RefreshToken").Result
            };
        }
        public LoginResponse RefreshToken(RefreshTokenRequest model)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(model.AccessToken);
            var name = jwt.Claims.First().Value;

            var user = userManager.FindByNameAsync(name).Result;

            if (user == null || !userManager.VerifyUserTokenAsync(user, "MyApp", "RefreshToken", model.RefreshToken).Result)
            {
                return null;
            }

            var userRoles = userManager.GetRolesAsync(user).Result;

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "RefreshToken").Wait();
            var newRefreshToken = userManager.GenerateUserTokenAsync(user, "MyApp", "RefreshToken").Result;
            userManager.SetAuthenticationTokenAsync(user, "MyApp", "RefreshToken", newRefreshToken).Wait();

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
                RefreshToken = newRefreshToken
            };
        }
    }
}
