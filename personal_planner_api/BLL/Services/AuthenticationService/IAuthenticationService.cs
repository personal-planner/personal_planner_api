using DTO;

namespace BLL
{
    public interface IAuthenticationService
    {
        RegistrationResponse Register(RegisterRequest model);
        LoginResponse Login(LoginRequest model);
    }
}
