using Microsoft.AspNetCore.Identity;

namespace Pierre_s_sweet_and_savory_treats.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add additional properties for user profile
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Additional properties for email and password
        public override string Email { get; set; }
        public override string NormalizedEmail { get; set; }
        public override string PasswordHash { get; set; }
    }
}
