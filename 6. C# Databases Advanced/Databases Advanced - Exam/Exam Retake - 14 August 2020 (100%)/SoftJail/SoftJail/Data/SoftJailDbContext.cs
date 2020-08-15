namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

        }

        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OfficerPrisoner>(entity =>
            {
                entity.HasKey(k => new { k.PrisonerId, k.OfficerId });

                entity
                .HasOne(p => p.Prisoner)
                .WithMany(s => s.PrisonerOfficers)
                .HasForeignKey(p => p.PrisonerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.Officer)
                .WithMany(s => s.OfficerPrisoners)
                .HasForeignKey(o => o.OfficerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}