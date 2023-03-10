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

        [ForeignKey("IdTypeVisite")]
        [Column("tvs_id", Order = 0)]
        [Required]
        public int IdTypeVisite { get; set; }

        [ForeignKey("IdPartenaire")]
        [Column("cav_id", Order = 1)]
        [Required]
        public int IdPartenaire { get; set; }

        [Column("vst_libelle")]
        [StringLength(255, ErrorMessage = "the libelle must be 255 maximum")]
        public string LibelleVisite { get; set; }

        [Column("vst_description", TypeName = "text")]
        public string DescriptionVisite { get; set; }

        [Column("vst_horaire")]
        public TimeOnly HoraireVisite { get; set; }

        [InverseProperty(nameof(FaitPartieDe.VisiteFaitPartieDeNavigation))]
        public virtual ICollection<FaitPartieDe> FaitPartieDeVisiteNavigation { get; set; } = new List<FaitPartieDe>();

        [InverseProperty(nameof(TypeVisite.VisiteTypeVisiteNavigation))]
        public virtual TypeVisite TypeVisiteVisiteNavigation { get; set; } = null!;

        [InverseProperty(nameof(Cave.VisiteCaveNavigation))]
        public virtual Cave CaveVisiteNavigation { get; set; } = null!;



    }
}
