using Educal_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Educal_MVC.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Category>().HasQueryFilter(m=>!m.SoftDeleted);
            modelbuilder.Entity<Course>().HasQueryFilter(m => !m.SoftDeleted);
            base.OnModelCreating(modelbuilder);
        }
    }
}
