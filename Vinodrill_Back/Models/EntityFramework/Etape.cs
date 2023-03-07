using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_etape_etp")]
    public partial class Etape
    {

        [ForeignKey("fk_etp_sje")]
        [Column("sjr_id", Order = 0)]
        public int IdSejour { get; set; }

        [ForeignKey("fk_etp_hbg")]
        [Column("hbg_id", Order = 1)]
        public int IdHebergement{ get; set; }

        [Key]
        [Column("etp_id")]
        public int IdEtape { get; set; }

        [Column("etp_titre")]
        [StringLength(255, ErrorMessage = " titre lenght must be 255 maximum")]
        [Required]
        public string TitreEtape { get; set; }

        [Column("etp_description")]
        [Required]
        public string DescriptionEtape { get; set; }

        [Column("etp_photo")]
        [Required]
        public string PhotoEtape { get; set; }

        [Column("etp_url")]
        [StringLength(255, ErrorMessage = " URL lenght must be 255 maximum")]
        [Required]
        public string UrlEtape { get; set; }

        [Column("etp_video")]
        [StringLength(255, ErrorMessage = " Video lenght must be 255 maximum")]
        [Required]
        public string VideoEtape { get; set; }
    }
}
