using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_bonreduction_brdc")]
    public partial class BonReduction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("brdc_id")]
        public int IdBonReduction { get; set; }

        [ForeignKey("fk_cmd_brdc")]
        [Required]
        [Column("cmd_id")]
        public int RefCommande { get; set; }

        [Required]
        [Column("brdc_codebonreduction")]
        [StringLength(255)]
        public string CodeBonReduction { get; set; }

        [Required]
        [Column("brdc_datevalidite", TypeName = "date")]
        public DateTime DateValidite { get; set; }

        [Required]
        [Column("brdc_estvalide")]
        public bool EstValide { get; set; }

        [InverseProperty(nameof(Commande.BonReductionNavigation))]
        public virtual Commande CommandeNavigation { get; set; } = null!;

    }
}
