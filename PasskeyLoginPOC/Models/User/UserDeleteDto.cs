using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PasskeyLoginPOC.API.Models.User
{
    public class UserDeleteDto
    {
        [Required]
       
        public int Id { get; set; }
    }
}
