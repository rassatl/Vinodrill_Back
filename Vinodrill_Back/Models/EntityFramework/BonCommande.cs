using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_boncommande_bcmd")]
    public partial class BonCommande
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("bcmd_id")]
        public int IdBonCommande { get; set; }

        
        [ForeignKey("fk_cmd_bcmd")]
        [Column("cmd_id")]
        [Required]
        public int RefCommande { get; set; }

        [Column("bcmd_codeboncommande")]
        [StringLength(255, ErrorMessage = "codeboncommande length must be 255 maximum")]
        [Required]
        public string CodeBonCommande { get; set; }

        [Column("bcmd_datevalidite", TypeName = "date")]
        [Required]
        public DateTime DateValidite { get; set; }

        [Column("bcmd_estvalide")]
        [Required]
        public bool EstValide { get; set; }

        [InverseProperty(nameof(Commande.BonCommandeNavigation))]
        public virtual Commande CommandeNavigation { get; set; } = null!;

    }
}
