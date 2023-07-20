using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
