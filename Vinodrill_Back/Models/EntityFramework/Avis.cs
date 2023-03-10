using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_avis_avi")]
    public partial class Avis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("avi_id")]
        public int IdAvis { get; set; }

        [ForeignKey("IdClient")]
        [Column("clt_id", Order = 0)]
        public int IdClient { get; set;}

        [ForeignKey("IdSejour")]
        [Column("sjr_id", Order = 1)]
        public int IdSejour { get; set; }

        [Column("avi_note")]
        [Range(0, 5)]
        [Required]
        public int Note { get;set;}

        [Column("avi_commentaire", TypeName = "text")]
        [Required]
        public string Commentaire { get; set; }

        [Column("avi_titreavis")]
        [StringLength(255)]
        public string TitreAvis { get;set; }

        [Column("avi_dateavis", TypeName = "date")]
        [Required]
        public DateTime DateAvis { get; set; } = DateTime.Now;

        [Column("avi_avissignale")]
        [Required]
        public bool AvisSignale { get; set; }

        [Column("avi_typesignalement")]
        [Required]
        [StringLength(255, ErrorMessage = "type signalement lenght must be 255 maximum")]
        public string? TypeSignalement { get; set; }

        [InverseProperty(nameof(ReponseAvis.AvisReponseAvisNavigation))]
        public virtual ICollection<ReponseAvis> ReponseAvisAvisNavigation { get; set; } = new List<ReponseAvis>();

        [InverseProperty(nameof(Client.AvisClientNavigation))]
        public virtual Client ClientAvisNavigation { get; set; } = null!;

        [InverseProperty(nameof(ImageAvis.AvisImageAvisNavigation))]
        public virtual ICollection<ImageAvis> ImageAvisAvisNavigation { get; set; } = new List<ImageAvis>();

        [InverseProperty(nameof(Sejour.AvisSejourNavigation))]
        public virtual Sejour SejourAvisNavigation { get; set; } = null!;
    }
}
