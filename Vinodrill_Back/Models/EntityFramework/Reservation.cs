using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_reservation_rsrv")]
    public partial class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_cmd_rsrv")]
        [Column("cmd_id", Order = 0)]
        public int RefCommande { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_sjr_rsrv")]
        [Column("sjr_id", Order = 1)]
        public int IdSejour { get; set; }

        [Column("rsrv_datedebutreservation", TypeName = "date")]
        [Required]
        public DateTime DateDebutReservation { get; set; }

        [Column("rsrv_estcadeau")]
        [Required]
        public bool EstCadeau { get; set; }

        [Column("rsrv_nbenfant")]
        [Required]
        public int NbEnfant { get; set; }

        [Column("rsrv_nbadulte")]
        [Required]
        public int NbAdulte { get; set; }

        [Column("rsrv_nbchambre")]
        [Required]
        public int NbChambre { get; set; }
    }
}
