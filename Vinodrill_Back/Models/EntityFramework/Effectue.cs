using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_effectue_efc")]
    public partial class Effectue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_vst_efc")]
        [Column("act_id", Order = 0)]
        public int IdActivite { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_etp_efc")]
        [Column("etp_id", Order = 1)]
        public int IdEtape { get; set; }

        [InverseProperty(nameof(Activite.EffectueActiviteNavigation))]
        public virtual Activite ActiviteEffectueNavigation { get; set; } = null!;

        [InverseProperty(nameof(Etape.EffectueEtapeNavigation))]
        public virtual Etape EtapeEffectueNavigation { get; set; } = null!;
    }
}
