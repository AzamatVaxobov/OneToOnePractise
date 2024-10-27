using Microsoft.EntityFrameworkCore;
using OneToOne.DataAccess.Entities;

namespace OneToOne.DataAccess
{
    public class MainContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Passport> Passports { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Passport)
                .WithOne(p => p.Person)
                .HasForeignKey<Passport>(p => p.PersonId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
