using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_avis_avis")]
    public partial class Avis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("avis_id")]
        public int IdAvis { get; set; }

        [ForeignKey("fk_clt_avis")]
        [Column("clt_id", Order = 0)]
        public int IdClient { get; set;}

        [ForeignKey("fk_sej_avis")]
        [Column("sjr_id", Order = 1)]
        public int IdSejour { get; set; }

        [Column("avis_note")]
        [Range(0, 5)]
        [Required]
        public int Note { get;set;}

        [Column("avis_commentaire")]
        [Required]
        public string Commentaire { get; set; }

        [Column("avis_titreavis")]
        [Required]
        [StringLength(255, ErrorMessage = " titre lenght must be 255 maximum")]
        public string Commentairea { get;set; }

        [Column("avis_dateavis", TypeName = "date")]
        [Required]
        public DateTime DateAvis { get; set; } = DateTime.Now;

        [Column("avis_avissignale")]
        [Required]
        public bool AvisSignale { get; set; }

        [Column("avis_typesignalement")]
        [Required]
        [StringLength(255, ErrorMessage = " type signalement lenght must be 255 maximum")]
        public string? TypeSignalement { get; set; }

        [Column("avis_estreponse")]
        [Required]
        public bool EstReponse { get; set; }
    }
}
