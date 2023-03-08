using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_catparticipant_cppt")]
    public partial class CatParticipant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cppt_id")]
        public int IdCategorieParticipant { get; set; }

        [Column("cppt_nom")]
        [StringLength(255, ErrorMessage = "the length of the name must be 255 maximum")]
        [Required]
        public string NomCategorieParticipant { get; set; }

        [InverseProperty(nameof(Participe.CatParticipantParticipeNavigation))]
        public virtual ICollection<Participe> ParticipeCatParticipantNavigation { get; set; } = new List<Participe>();
    }
}
