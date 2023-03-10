using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_faitpartiede_fpd")]
    public partial class FaitPartieDe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdVisite")]
        [Column("vst_id", Order = 0)]
        public int IdVisite { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdEtape")]
        [Column("etp_id", Order = 1)]
        public int IdEtape { get; set; }

        [InverseProperty(nameof(Visite.FaitPartieDeVisiteNavigation))]
        public virtual Visite VisiteFaitPartieDeNavigation { get; set; } = null!;

        [InverseProperty(nameof(Etape.FaitPartieDeEtapeNavigation))]
        public virtual Etape EtapeFaitPartieDeNavigation { get; set; } = null!;
    }
}
