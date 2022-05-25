using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTO
{
    public class RefreshTokenRequest
    {
        [JsonIgnore]
        public string AccessToken { get; set; }
        [Required(ErrorMessage = "Refresh Token is required")]
        public string RefreshToken { get; set; }
    }

    public class LoginRequest
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
