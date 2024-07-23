using Microsoft.EntityFrameworkCore;
using Multilingual.Common;
using Multilingual.Entities;

namespace Multilingual.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StringResource>()
                .HasIndex(sr => new { sr.Key, sr.LanguageId })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<StringResource> StringResources { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
