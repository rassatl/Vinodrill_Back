using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_adopte_adpt")]
    public partial class Adopte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_clt_adpt")]
        [Column("clt_id", Order = 0)]
        public int IdClient { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_cke_adpt")]
        [Column("cke_id", Order = 1)]
        public int IdCookie { get; set; }

        [Column("adpt_consentement")]
        public bool ConsentementAdopte { get; set; }
    }
}
