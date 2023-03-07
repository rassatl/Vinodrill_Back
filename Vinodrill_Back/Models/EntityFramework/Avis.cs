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
        [Column("avis_idclient")]
        public int IdClient { get; set;}

        [ForeignKey("fk_sej_avis")]
        [Column("avis_idsejour")]
        public int IdSejour { get; set; }

        [Column("avis_note")]
        public int Note { get;set;}

        [Column("avis_commentaire")]
        public string Commentaire { get; set; }

        [Column("avis_titreavis")]
        [StringLength(255)]
        public string TitreAvis { get;set; }

        [Column("avis_dateavis", TypeName = "date")]
        public DateTime DateAvis { get; set; } = DateTime.Now;

        [Column("avis_avissignale")]
        public bool AvisSignale { get; set; } = false;

        [Column("avis_typesignalement")]
        [StringLength(255)]
        public string? TypeSignalement { get; set; }

        [InverseProperty(nameof(ReponseAvi.RepReponseAvi))]
        public ICollection<ReponseAvi> RepAvi { get; set; } = null!;
    }
}
