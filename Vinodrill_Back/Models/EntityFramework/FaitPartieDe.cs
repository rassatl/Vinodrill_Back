using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_faitpartiede_fpd")]
    public partial class FaitPartieDe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_vst_fpd")]
        [Column("vst_id", Order = 0)]
        public int IdVisite { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_etp_fpd")]
        [Column("etp_id", Order = 1)]
        public int IdEtape { get; set; }
    }
}
