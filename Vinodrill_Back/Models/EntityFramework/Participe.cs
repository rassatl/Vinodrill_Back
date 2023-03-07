using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_participe_ppt")]
    public partial class Participe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_cppt_ppt")]
        [Column("cppt_id", Order = 0)]
        public int IdCategorieParticipant { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_sjr_ppt")]
        [Column("sjr_id", Order = 1)]
        public int IdSejour { get; set; }
    }
}
