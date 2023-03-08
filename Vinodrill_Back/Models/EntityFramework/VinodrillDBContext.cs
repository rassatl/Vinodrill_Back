using Microsoft.EntityFrameworkCore;

namespace Vinodrill_Back.Models.EntityFramework
{
    public class VinodrillDBContext : DbContext 
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public VinodrillDBContext()
        { }
        public VinodrillDBContext(DbContextOptions<VinodrillDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commande>(entity =>
            {
                entity.Property(c => c.Quantite);
            });
        }
    }
}
