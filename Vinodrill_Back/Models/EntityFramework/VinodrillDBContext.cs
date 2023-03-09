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
        public virtual DbSet<Activite> Activites { get; set; } = null!;

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

            modelBuilder.Entity<Effectue>(entity =>
            {
                entity.HasKey(e => new { e.IdActivite, e.IdEtape })
                    .HasName("pk_effectue");
            });

            modelBuilder.Entity<ImageAvis>(entity =>
            {
                entity.HasKey(e => new { e.IdImage, e.IdAvis })
                    .HasName("pk_image_avis");
            });

            modelBuilder.Entity<Participe>(entity =>
            {
                entity.HasKey(p => new { p.IdCategorieParticipant , p.IdSejour })
                    .HasName("pk_participe");
            });

            modelBuilder.Entity<ReponseAvis>(entity =>
            {
                entity.HasKey(r => new { r.Id, r.IdAvis })
                    .HasName("pk_reponse_avis");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(r => new { r.IdSejour, r.RefCommande })
                    .HasName("pk_reservation");
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
