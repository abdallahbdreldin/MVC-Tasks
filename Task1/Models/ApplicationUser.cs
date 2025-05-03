using Microsoft.AspNetCore.Identity;

namespace Task1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
