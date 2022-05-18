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
        private readonly RoleManager<GuidRole> roleManager;
        private readonly SignInManager<UserModel> signInManager;
        private readonly IConfiguration configuration;

        public AuthenticationService(UserManager<UserModel> userManager, RoleManager<GuidRole> roleManager, SignInManager<UserModel> signInManager, IConfiguration configuration)
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

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}
