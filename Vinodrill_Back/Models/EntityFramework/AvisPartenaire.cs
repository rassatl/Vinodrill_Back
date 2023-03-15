using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_avispartenaire_apr")]
    public partial class AvisPartenaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("apr_id")]
        public int IdAvisPartenaire { get; set; }

        [ForeignKey("IdClient")]
        [Column("usr_id", Order = 0)]
        public int IdClient { get; set;}

        [ForeignKey("IdPartenaire")]
        [Column("par_id", Order = 1)]
        public int IdPartenaire { get; set; }

        [Column("apr_commentaire", TypeName = "text")]
        [StringLength(255)]
        [Required]
        public string CommentaireAvis { get;set; }

        [Column("apr_dateavis", TypeName = "date")]
        [Required]
        public DateTime DateAvis { get; set; } = DateTime.Now;

        [Column("avi_avissignale")]
        public bool AvisSignale { get; set; } = false;

        [Column("avi_typesignalement")]
        [StringLength(255, ErrorMessage = "type signalement lenght must be 255 maximum")]
        public string? TypeSignalement { get; set; }

        [InverseProperty(nameof(User.AvisPartenaireClientNavigation))]
        public virtual User ClientAvisPartenaireNavigation { get; set; } = null!;

        [InverseProperty(nameof(Partenaire.AvisPartenairePartenaireNavigation))]
        public virtual Partenaire PartenaireAvisPartenaireNavigation { get; set; } = null!;
    }
}