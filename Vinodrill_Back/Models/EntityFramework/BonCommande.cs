using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_boncommande_bcm")]
    public partial class BonCommande
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("bcm_id")]
        public int IdBonCommande { get; set; }

        
        [ForeignKey("fk_cmd_bcm")]
        [Column("cmd_id")]
        [Required]
        public int RefCommande { get; set; }

        [Column("bcm_codeboncommande")]
        [StringLength(255, ErrorMessage = "codeboncommande length must be 255 maximum")]
        [Required]
        public string CodeBonCommande { get; set; }

        [Column("bcm_datevalidite", TypeName = "date")]
        [Required]
        public DateTime DateValidite { get; set; }

        [Column("bcm_estvalide")]
        [Required]
        public bool EstValide { get; set; }

        [InverseProperty(nameof(Commande.BonCommandeCommandeNavigation))]
        public virtual ICollection<Commande> CommandeBonCommandeNavigation { get; set; } = null;

    }
}
