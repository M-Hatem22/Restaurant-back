

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RestaurantApp.DAL.Data.Context
{
    public class UserContext : IdentityDbContext
    {
        
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         

            modelBuilder.Entity<IdentityUser>()
            .ToTable("AspNetUsers").HasKey(k => k.Id);

            
        }

        
    }
    }

