using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_adopte_adp")]
    public partial class Adopte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_clt_adp")]
        [Column("clt_id", Order = 0)]
        public int IdClient { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_cke_adp")]
        [Column("cke_id", Order = 1)]
        public int IdCookie { get; set; }

        [Column("adp_consentement")]
        public bool ConsentementAdopte { get; set; }
    }
}
