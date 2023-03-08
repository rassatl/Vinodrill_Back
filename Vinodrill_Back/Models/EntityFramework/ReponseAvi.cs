using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_reponseavis_rav")]
    public partial class ReponseAvi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("rav_id")]
        public int Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_avi_repavs")]
        [Column("rav_idavis")]
        public int IdAvis { get; set;}

        [Column("rav_commentaire")]
        public string Commentaire { get; set; }

        [InverseProperty(nameof(Avis.RepAvi))]
        public virtual Avis RepReponseAvi { get; set; } = null!;
    }
}
