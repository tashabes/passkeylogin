using System.ComponentModel.DataAnnotations;

namespace PasskeyLoginPOC.API.Models.Users
{
    public class LoginUserDto
    {
        [Required]
        public string MachineName { get; set; }
       
    }
}