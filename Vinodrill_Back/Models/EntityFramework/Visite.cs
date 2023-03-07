using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_visite_vst")]
    public partial class Visite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("vst_id")]
        public int IdVisite { get; set; }

        [ForeignKey("fk_tvst_vst")]
        [Column("tvst_idtypevisite", Order = 0)]
        [Required]
        public int IdTypeVisite { get; set; }

        [ForeignKey("fk_tvst_vrt")]
        [Column("prt_id", Order = 1)]
        [Required]
        public int IdPartenaire { get; set; }

        [Column("vst_libelle")]
        [StringLength(255, ErrorMessage = "the libelle must be 255 maximum")]
        public string LibelleVisite { get; set; }

        [Column("vst_description")]
        public string DescriptionVisite { get; set; }

        [Column("vst_horaire")]
        public TimeOnly HoraireVisite { get; set; }

    }
}
