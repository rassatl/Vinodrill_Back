using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_adopte_adpt")]
    public partial class Adopte
    {
        [ForeignKey("fk_adpt_clt")]
        [Column("clt_id", Order = 0)]
        public int IdClient { get; set; }

        [ForeignKey("fk_adpt_clt")]
        [Column("cke_id", Order = 1)]
        public int IdCookie { get; set; }

        [Column("adpt_consentement")]
        public bool ConsentementAdopte { get; set; }
    }
}
