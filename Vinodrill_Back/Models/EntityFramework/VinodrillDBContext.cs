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
            //modelBuilder.Entity<Adopte>(entity =>
            //{
            //    entity.HasOne(d => d.fk_clt_adt)
            //        .WithMany(p => p.ImageAvisImageNavigation)
            //        .HasForeignKey(d => d.IdImage)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("fk_clt_adt");
            //});

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasCheckConstraint("ck_cmd_prix", "cmd_quantite > 0");

                entity.HasOne(d => d.ClientCommandeNavigation)
                    .WithMany(p => p.CommandeClientNavigation)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clt_cmd");

                entity.HasOne(d => d.PaiementCommandeNavigation)
                    .WithMany(p => p.CommandePaiementNavigation)
                    .HasForeignKey(d => d.IdPaiement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pmt_cmd");
            });

            modelBuilder.Entity<FaitPartieDe>(entity =>
            {
                entity.HasKey(e => new { e.IdVisite, e.IdEtape })
                    .HasName("pk_fait_parti_de");

                entity.HasOne(d => d.VisiteFaitPartieDeNavigation)
                    .WithMany(p => p.FaitPartieDeVisiteNavigation)
                    .HasForeignKey(d => d.IdVisite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vst_fpd");
                entity.HasOne(d => d.EtapeFaitPartieDeNavigation)
                    .WithMany(p => p.FaitPartieDeEtapeNavigation)
                    .HasForeignKey(d => d.IdEtape)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_etp_fpd");
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

                entity.HasOne(d => d.AvisImageAvisNavigation)
                    .WithMany(p => p.ImageAvisAvisNavigation)
                    .HasForeignKey(d => d.IdAvis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avi_ima");

                entity.HasOne(d => d.ImageImageAvisNavigation)
                    .WithMany(p => p.ImageAvisImageNavigation)
                    .HasForeignKey(d => d.IdImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_img_ima");
            });

            modelBuilder.Entity<Participe>(entity =>
            {
                entity.HasKey(p => new { p.IdCategorieParticipant, p.IdSejour })
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

            modelBuilder.Entity<EtoileHotel>(entity =>
            {
                entity.HasCheckConstraint("ck_eth_nb", "eth_nb between 0 and 5");
            });

            modelBuilder.Entity<Activite>(entity =>
            {
                entity.HasOne(d => d.SocieteActiviteNavigation)
                    .WithMany(p => p.ActiviteSocieteNavigation)
                    .HasForeignKey(d => d.IdPartenaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prt_act");
            });

            modelBuilder.Entity<Partenaire>(entity =>
            {
                entity
                   .HasIndex(e => e.EmailPartenaire)
                   .IsUnique()
                   .HasDatabaseName("uq_prt_email");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity
                   .HasIndex(e => e.EmailClient)
                   .IsUnique()
                   .HasDatabaseName("uq_clt_email");

                //entity.HasOne(d => d.CbClientNavigation)
                //    .Has(p => p.ClientCbNavigation)
                //    .HasForeignKey(d => d.IdClient)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("fk_clt_adr");
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.HasOne(d => d.ClientAdresseNavigation)
                    .WithMany(p => p.AdresseClientNavigation)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clt_adr");
            });

            modelBuilder.Entity<Avis>(entity =>
            {
                entity.HasOne(d => d.ClientAvisNavigation)
                    .WithMany(p => p.AvisClientNavigation)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clt_avi");

                entity.HasOne(d => d.SejourAvisNavigation)
                    .WithMany(p => p.AvisSejourNavigation)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sej_avi");
            });

            modelBuilder.Entity<BonCommande>(entity =>
            {
                entity.HasOne(d => d.CommandeBonCommandeNavigation)
                    .WithMany(p => p.BonCommandeCommandeNavigation)
                    .HasForeignKey(d => d.IdBonCommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cmd_bcm");
            });

            modelBuilder.Entity<BonReduction>(entity =>
            {
                entity.HasOne(d => d.CommandeBonReductionNavigation)
                    .WithMany(p => p.BonReductionCommandeNavigation)
                    .HasForeignKey(d => d.RefCommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cmd_brd");
            });

            modelBuilder.Entity<BonReduction>(entity =>
            {
                entity.HasOne(d => d.CommandeBonReductionNavigation)
                    .WithMany(p => p.BonReductionCommandeNavigation)
                    .HasForeignKey(d => d.RefCommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cmd_brd");
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(e => new { e.IdDestination })
                    .HasName("pk_destination");
            });
            modelBuilder.Entity<Effectue>(entity =>
            {
                entity.HasKey(e => new { e.IdActivite, e.IdEtape })
                    .HasName("pk_effectue");

                entity.HasOne(d => d.ActiviteEffectueNavigation)
                    .WithMany(p => p.EffectueActiviteNavigation)
                    .HasForeignKey(d => d.IdActivite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vst_efc");
                entity.HasOne(d => d.EtapeEffectueNavigation)
                    .WithMany(p => p.EffectueEtapeNavigation)
                    .HasForeignKey(d => d.IdEtape)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_etp_efc");

            });
            modelBuilder.Entity<Etape>(entity =>
            {
                entity.HasOne(d => d.SejourEtapeNavigation)
                    .WithMany(p => p.EtapeSejourNavigation)
                    .HasForeignKey(d => d.IdSejour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sje_etp");
                entity.HasOne(d => d.HebergementEtapeNavigation)
                    .WithMany(p => p.EtapeHebergementNavigation)
                    .HasForeignKey(d => d.IdHebergement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hbg_etp");
            });
            modelBuilder.Entity<Hebergement>(entity =>
            {
                entity.HasOne(d => d.HotelHebergementNavigation)
                    .WithMany(p => p.HebergementHotelNavigation)
                    .HasForeignKey(d => d.IdPartenaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prt_hbg");
            });
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasOne(d => d.EtoileHotelHotelNavigation)
                    .WithMany(p => p.HotelEtoileHotelNavigation)
                    .HasForeignKey(d => d.NbEtoileHotel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_eth_htl");
            });
            modelBuilder.Entity<Participe>(entity =>
            {
                entity.HasKey(p => new { p.IdCategorieParticipant, p.IdSejour })
                    .HasName("pk_participe");
                entity.HasOne(d => d.CatParticipantParticipeNavigation)
                    .WithMany(p => p.ParticipeCatParticipantNavigation)
                    .HasForeignKey(d => d.IdCategorieParticipant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cpt_ppt");
                entity.HasOne(d => d.SejourParticipeNavigation)
                    .WithMany(p => p.ParticipeSejourNavigation)
                    .HasForeignKey(d => d.IdSejour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sjr_ppt");
            });
            modelBuilder.Entity<Paiement>(entity =>
            {
                entity.HasOne(d => d.ClientPaiementNavigation)
                    .WithMany(p => p.PaiementClientNavigation)
                    .HasForeignKey(d => d.IdClientPaiement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clt_pmt");
            });
            modelBuilder.Entity<ReponseAvis>(entity =>
            {
                entity.HasKey(r => new { r.Id, r.IdAvis })
                    .HasName("pk_reponse_avis");
                entity.HasOne(d => d.AvisReponseAvisNavigation)
                    .WithMany(p => p.ReponseAvisAvisNavigation)
                    .HasForeignKey(d => d.IdAvis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avi_rav");
            });
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(r => new { r.IdSejour, r.RefCommande })
                    .HasName("pk_reservation");
                entity.HasOne(d => d.CommandeReservationNavigation)
                    .WithMany(p => p.ReservationCommandeNavigation)
                    .HasForeignKey(d => d.RefCommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cmd_rsv");
                entity.HasOne(d => d.SejourReservationNavigation)
                    .WithMany(p => p.ReservationSejourNavigation)
                    .HasForeignKey(d => d.IdSejour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sjr_rsv");
            });
            modelBuilder.Entity<Societe>(entity =>
            {
                entity.HasOne(d => d.TypeActiviteSocieteNavigation)
                    .WithMany(p => p.SocieteTypeActiviteNavigation)
                    .HasForeignKey(d => d.IdTypeActivite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tac_sct");
            });
            modelBuilder.Entity<Sejour>(entity =>
            {
                entity.HasOne(d => d.DestinationSejourNavigation)
                    .WithMany(p => p.SejourDestinationNavigation)
                    .HasForeignKey(d => d.IdDestination)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dst_sjr");
                entity.HasOne(d => d.ThemeSejourNavigation)
                    .WithMany(p => p.SejourThemeNavigation)
                    .HasForeignKey(d => d.IdTheme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_thm_sjr");
            });
            modelBuilder.Entity<Visite>(entity =>
            {
                entity.HasOne(d => d.TypeVisiteVisiteNavigation)
                    .WithMany(p => p.VisiteTypeVisiteNavigation)
                    .HasForeignKey(d => d.IdTypeVisite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tvs_vst");
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
