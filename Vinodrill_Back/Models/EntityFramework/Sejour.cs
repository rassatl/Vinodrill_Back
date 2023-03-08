using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_sejour_sjr")]
    public partial class Sejour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("sjr_id")]
        public int IdSejour { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_dst_sjr")]
        [Column("dst_id", Order = 1)]
        public int IdDestination { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_thm_sjr")]
        [Column("thm_id", Order = 0)]
        public int IdTheme { get; set; }

        [Column("sjr_titre")]
        [StringLength(255, ErrorMessage = "titre lenght must be 255 maximum")]
        [Required]
        public string TitreSejour { get; set; }

        [Column("sjr_photo")]
        [StringLength(255, ErrorMessage = "photo lenght must be 255 maximum")]
        [Required]
        public string PhotoSejour { get; set; }

        [Column("sjr_prix")]
        [Required]
        public Decimal PrixSejour { get; set; }

        [Column("sjr_description", TypeName = "text")]
        [Required]
        public string DescriptionSejour { get; set; }

        [Column("sjr_nbjour")]
        [Required]
        public int NbJour { get; set; }

        [Column("sjr_nbnuit")]
        [Required]
        public int NbNuit { get; set; }

        [Column("sjr_libelletemps")]
        [StringLength(255, ErrorMessage = " libelletemps lenght must be 255 maximum")]
        [Required]
        public string LibelleTemps { get; set; }

        [Column("sjr_notemoyenne")]
        [Required]
        public Decimal NoteMoyenne { get; set; }

        [InverseProperty(nameof(Reservation.SejourReservationNavigation))]
        public virtual ICollection<Reservation> ReservationSejourNavigation { get; set; } = new List<Reservation>();

        [InverseProperty(nameof(Participe.SejourParticipeNavigation))]
        public virtual ICollection<Participe> ParticipeSejourNavigation { get; set; } = new List<Participe>();

        [InverseProperty(nameof(Destination.SejourDestinationNavigation))]
        public virtual Destination DestinationSejourNavigation { get; set; } = null!;

        [InverseProperty(nameof(Theme.SejourThemeNavigation))]
        public virtual Theme ThemeSejourNavigation { get; set; } = null!;

        [InverseProperty(nameof(Etape.SejourEtapeNavigation))]
        public virtual ICollection<Etape> EtapeSejourNavigation { get; set; } = new List<Etape>();

        [InverseProperty(nameof(Avis.SejourAvisNavigation))]
        public virtual ICollection<Avis> AvisSejourNavigation { get; set; } = new List<Avis>();
    }
}
