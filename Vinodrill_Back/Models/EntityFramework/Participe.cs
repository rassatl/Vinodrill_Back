using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_participe_ppt")]
    public partial class Participe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdCategorieParticipant")]
        [Column("cpt_id", Order = 0)]
        public int IdCategorieParticipant { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdSejour")]
        [Column("sjr_id", Order = 1)]
        public int IdSejour { get; set; }

        [InverseProperty(nameof(CatParticipant.ParticipeCatParticipantNavigation))]
        public virtual CatParticipant CatParticipantParticipeNavigation { get; set; } = null!;

        [InverseProperty(nameof(Sejour.ParticipeSejourNavigation))]
        public virtual Sejour SejourParticipeNavigation { get; set; } = null!;
    }
}
