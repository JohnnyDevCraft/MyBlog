using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyBlog.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
    }
}