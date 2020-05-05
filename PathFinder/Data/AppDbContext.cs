using Microsoft.EntityFrameworkCore;
using PathFinder.Data.Models;

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
    }
}