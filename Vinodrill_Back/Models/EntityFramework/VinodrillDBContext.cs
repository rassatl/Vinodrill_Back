using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Vinodrill_Back.Models.EntityFramework
{
    public partial class VinodrillDBContext : DbContext 
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
                entity.HasCheckConstraint("ck_cmd_prix", "cmd_quantite > 0");
            });

            modelBuilder.Entity<FaitPartieDe>(entity =>
            {
                entity.HasKey(e => new { e.IdVisite, e.IdEtape })
                    .HasName("pk_fait_parti_de");
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
