using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_catparticipant_cpt")]
    public partial class CatParticipant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cpt_id")]
        public int IdCategorieParticipant { get; set; }

        [Column("cpt_nom")]
        [StringLength(255, ErrorMessage = "the length of the name must be 255 maximum")]
        [Required]
        public string NomCategorieParticipant { get; set; }

        [InverseProperty(nameof(Commande.CategorieParticipantCommandeNavigation))]
        public virtual ICollection<Commande> CommandeCategorieParticipantNavigation { get; set; } = null;
    }
}
