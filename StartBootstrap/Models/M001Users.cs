using Microsoft.AspNetCore.Identity;

namespace StartBootstrap.Models
{
    public class M001Users:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}
