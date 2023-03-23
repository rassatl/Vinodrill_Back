using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_reponseavis_rav")]
    public partial class ReponseAvis
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("rav_id")]
        public int IdReponseAvis { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdAvis")]
        [Column("rav_idavis")]
        public int IdAvis { get; set;}

        [Column("rav_commentaire")]
        public string Commentaire { get; set; }

        [InverseProperty(nameof(Avis.ReponseAvisAvisNavigation))]
        public virtual Avis? AvisReponseAvisNavigation { get; set; } = null!;
    }
}
