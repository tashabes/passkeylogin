using System.ComponentModel.DataAnnotations;

namespace PasskeyLoginPOC.API.Models.Users
{
    public class UserDto : LoginUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string PhoneNumber { get; set; }
        [Required]
      
        public string Role { get; set; }
    }
}