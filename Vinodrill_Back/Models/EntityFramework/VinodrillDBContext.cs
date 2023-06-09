﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using Vinodrill_Back.Models.EntityFramework;

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
        public virtual DbSet<Adresse> Adresses { get; set; } = null!;
        public virtual DbSet<Visite> Visites { get; set; } = null!;
        public virtual DbSet<TypeVisite> TypeVisites { get; set; } = null!;
        public virtual DbSet<Theme> Themes { get; set; } = null!;
        public virtual DbSet<Societe> Societes { get; set; } = null!;
        public virtual DbSet<Participe> Participes { get; set; } = null!;
        public virtual DbSet<Avis> Avis { get; set; } = null!;
        public virtual DbSet<CatParticipant> Catparticipants { get; set; } = null!;
        public virtual DbSet<Cave> Caves { get; set; } = null!;
        public virtual DbSet<User> Clients { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Partenaire> Partenaires { get; set; } = null!;
        public virtual DbSet<Commande> Commandes { get; set; } = null!;
        public virtual DbSet<Sejour> Sejours { get; set; } = null!;
        public virtual DbSet<BonCommande> BonCommandes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Hebergement> Hebergements { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Effectue> Effectues { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<BonReduction> BonReductions { get; set; } = null!;
        public virtual DbSet<Paiement> Paiements { get; set; } = null!;

        public virtual DbSet<ReponseAvis> ReponseAvis { get; set; } = null!;

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

            // // Use reflection to get all the entity types in the assembly
            // var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
            //     .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof()));

            // // Dynamically create the DbSet properties for each entity type
            // foreach (var entityType in entityTypes)
            // {
            //     modelBuilder.Entity(entityType);
            // }

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasOne(d => d.EtoileRestaurantRestaurantNavigation)
                    .WithMany(p => p.RestaurantEtoileRestaurantRestaurantNavigation)
                    .HasForeignKey(d => d.NbEtoileRestaurantRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_etr_res");

                entity.HasOne(d => d.TypeCuisineCuisineNavigation)
                    .WithMany(p => p.RestaurantTypeCuisineCuisineNavigation)
                    .HasForeignKey(d => d.IdTypeCuisineCuisine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tcu_res");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasCheckConstraint("ck_cmd_prix", "cmd_quantite > 0");

                entity.Property(e => e.EstCheque).HasDefaultValue(false);

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
                entity.HasKey(r => new { r.IdReponseAvis, r.IdAvis })
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
                //entity
                //   .HasIndex(e => e.EmailPartenaire)
                //   .IsUnique()
                //   .HasDatabaseName("uq_prt_email");
            });

            modelBuilder.Entity<User>(entity =>
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
                    .HasForeignKey(d => d.IdSejour)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sej_avi");

                entity.Property(e => e.AvisSignale).HasDefaultValue(false);
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

                entity.HasOne(d => d.PartenaireHotelNavigation)
                    .WithMany(p => p.HotelPartenaireNavigation)
                    .HasForeignKey(d => d.IdPartenaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prt_htl");
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
                entity.HasKey(r => new { r.IdReponseAvis, r.IdAvis })
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

                entity.HasOne(d => d.PartenaireSocieteNavigation)
                    .WithMany(p => p.SocietePartenaireNavigation)
                    .HasForeignKey(d => d.IdPartenaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prt_sct");
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

                entity.HasOne(d => d.CaveVisiteNavigation)
                    .WithMany(p => p.VisiteCaveNavigation)
                    .HasForeignKey(d => d.IdPartenaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cav_vst");
            });

            modelBuilder.Entity<Cave>(entity => {
                entity.HasOne(d => d.PartenaireCaveNavigation)
                    .WithMany(p => p.CavePartenaireNavigation)
                    .HasForeignKey(d => d.IdPartenaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prt_cav");
            });

            modelBuilder.Entity<AvisPartenaire>(entity => {
                entity.HasOne(d => d.PartenaireAvisPartenaireNavigation)
                    .WithMany(p => p.AvisPartenairePartenaireNavigation)
                    .HasForeignKey(d => d.IdPartenaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prt_avp");

                entity.HasOne(d => d.ClientAvisPartenaireNavigation)
                    .WithMany(p => p.AvisPartenaireClientNavigation)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clt_avp");

                entity.Property(e => e.AvisSignale).HasDefaultValue(false);
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        

    }
}
