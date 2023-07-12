using Microsoft.AspNetCore.Identity;

namespace PasskeyLoginPOC.API.Data
{
    public class ApiUser : IdentityUser
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string MachineName { get; set; }
    }
}
