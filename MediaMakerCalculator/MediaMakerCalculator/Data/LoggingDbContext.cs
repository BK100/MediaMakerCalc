using MediaMakerCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaMakerCalculator.Data
{
    public class LoggingDbContext : DbContext
    {
        public DbSet<LogItem> LogItems { get; set; }

        public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogItem>(entity =>
            {
                entity.HasKey(e => e.LogId);
                entity.Property(e => e.LogId);
                entity.Property(e => e.LogMessage);
                entity.Property(e => e.LogType);
                entity.Property(e => e.LogTime);
            });
        }
    }
}
