using Microsoft.AspNetCore.Identity;

namespace Pierre_s_sweet_and_savory_treats.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }
        public override string NormalizedEmail { get; set; }
        public override string PasswordHash { get; set; }
    }
}
