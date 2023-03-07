using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_imageavi_imga")]
    public partial class ImageAvi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_imga_avis")]
        [Column("avis_id", Order = 0)]
        public int IdAvis { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_imga_img")]
        [Column("img_id", Order = 1)]
        public int IdImage { get; set; }
    }
}
