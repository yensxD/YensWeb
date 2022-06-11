using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Yens.Models;

namespace Yens.DataAccess.Data
{
    public class AplicationDbContext: IdentityDbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {      
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
