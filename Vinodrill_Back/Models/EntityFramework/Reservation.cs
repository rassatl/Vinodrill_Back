using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_reservation_rsv")]
    public partial class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_cmd_rsv")]
        [Column("cmd_id", Order = 0)]
        public int RefCommande { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_sjr_rsv")]
        [Column("sjr_id", Order = 1)]
        public int IdSejour { get; set; }

        [Column("rsv_datedebutreservation", TypeName = "date")]
        [Required]
        public DateTime DateDebutReservation { get; set; }

        [Column("rsv_estcadeau")]
        [Required]
        public bool EstCadeau { get; set; }

        [Column("rsv_nbenfant")]
        [Required]
        public int NbEnfant { get; set; }

        [Column("rsv_nbadulte")]
        [Required]
        public int NbAdulte { get; set; }

        [Column("rsv_nbchambre")]
        [Required]
        public int NbChambre { get; set; }

        [InverseProperty(nameof(Commande.ReservationCommandeNavigation))]
        public virtual Commande CommandeReservationNavigation { get; set; } = null!;

        [InverseProperty(nameof(Sejour.ReservationSejourNavigation))]
        public virtual Sejour SejourReservationNavigation { get; set; } = null!;
    }
}
