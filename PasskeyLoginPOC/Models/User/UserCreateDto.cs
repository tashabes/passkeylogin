using System.ComponentModel.DataAnnotations;

namespace PasskeyLoginPOC.API.Models.User
{
    public class UserCreateDto : BaseDto
    {
       
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string MachineName { get; set; }
    }
}
