using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_bonreduction_brd")]
    public partial class BonReduction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("brd_id")]
        public int IdBonReduction { get; set; }

        [ForeignKey("fk_cmd_brd")]
        [Required]
        [Column("cmd_id")]
        public int RefCommande { get; set; }

        [Required]
        [Column("brd_codebonreduction")]
        [StringLength(255)]
        public string CodeBonReduction { get; set; }

        [Required]
        [Column("brd_datevalidite", TypeName = "date")]
        public DateTime DateValidite { get; set; }

        [Required]
        [Column("brd_estvalide")]
        public bool EstValide { get; set; }

        [InverseProperty(nameof(Commande.BonReductionCommandeNavigation))]
        public virtual ICollection<Commande> CommandeBonReductionNavigation { get; set; } = null;

    }
}
