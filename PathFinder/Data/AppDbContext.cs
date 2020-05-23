using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Models;
using PathFinder.Data.Models.CharClass;

namespace PathFinder.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Race> Races { get; set; }
        public DbSet<CharClass> CharClasses { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassAlignment>()
                .HasKey(x => new {x.CharClassId, x.AlignmentId});

            modelBuilder.Entity<ClassAlignment>()
                .HasOne(ca => ca.CharClass)
                .WithMany(c => c.ClassAlignments)
                .HasForeignKey(ca => ca.CharClassId);

            modelBuilder.Entity<ClassAlignment>()
                .HasOne(ca => ca.Alignment)
                .WithMany(a => a.ClassAlignments)
                .HasForeignKey(ca => ca.AlignmentId);
        }
    }
}