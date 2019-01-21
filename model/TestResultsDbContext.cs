using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System;

namespace dev.Model
{
    public class TestResultsDbContext : DbContext
    {
        public virtual DbSet<TestResult> TestResults { get; set; }

        public TestResultsDbContext(DbContextOptions<TestResultsDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("Created").CurrentValue = DateTime.Now;
                E.Property("Updated").CurrentValue = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("Updated").CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestResult>()
                .ToTable("testresult")
                .Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            modelBuilder.Entity<TestResult>()
                .ToTable("testresult")
                .Property(b => b.Name)
                .HasColumnName("name");

            modelBuilder.Entity<TestResult>()
                .ToTable("testresult")
                .Property(b => b.Source)
                .HasColumnName("source");

            modelBuilder.Entity<TestResult>()
                .ToTable("testresult")
                .Property(b => b.Created)
                .HasColumnName("created");
            
            modelBuilder.Entity<TestResult>()
                .ToTable("testresult")
                .Property(b => b.Updated)
                .HasColumnName("updated");
        }
    }
}