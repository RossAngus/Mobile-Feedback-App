using Glasgow123.MobileAppService.Models.Relationships;
using Glasgow123.Models;
using Microsoft.EntityFrameworkCore;

namespace Glasgow123.MobileAppService.Models
{
    public class SQLItemContext : DbContext
    {
        public virtual DbSet<UniversityClass> UniversityClasses { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<PersonClass> PersonClasses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:glasgow123-mobileappservicedbserver.database.windows.net,1433;Initial Catalog=Glasgow123-MobileAppService_db;Persist Security Info=False;User ID=cs02;Password=Team404!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Teacher Many-To-One
            modelBuilder.Entity<Person>()
                .HasMany(c => c.Teaches)
                .WithOne(e => e.Lecturer);
            // Student Many-to-Many
            modelBuilder.Entity<PersonClass>()
                .HasKey(pc => new { pc.PersonId, pc.UniversityClassId });
            modelBuilder.Entity<PersonClass>()
                .HasOne(pc => pc.Person)
                .WithMany(p => p.PersonClasses)
                .HasForeignKey(pc => pc.PersonId);
            modelBuilder.Entity<PersonClass>()
                .HasOne(pc => pc.UniversityClass)
                .WithMany(c => c.PersonClasses)
                .HasForeignKey(pc => pc.UniversityClassId);

            //Feedback set of relations
            modelBuilder.Entity<Person>()
                .HasMany(c => c.FeedbackReceived)
                .WithOne(e => e.ToPerson)
                .HasForeignKey(pc => pc.ToPersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
                .HasMany(c => c.FeedbackGiven)
                .WithOne(e => e.Author)
                .HasForeignKey(pc => pc.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UniversityClass>()
                .HasMany(c => c.FeedbackReceived)
                .WithOne(e => e.UniversityClass)
                .HasForeignKey(pc => pc.UniversityClassId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
