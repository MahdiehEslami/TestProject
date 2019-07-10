using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.UI.WebMVC.Models.AAA
{
    public class UserDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<BadPassword> BadPasswords { get; set; }
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
