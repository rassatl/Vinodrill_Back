using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_imageavi_ima")]
    public partial class ImageAvi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_avi_ima")]
        [Column("avi_id", Order = 0)]
        public int IdAvis { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_img_ima")]
        [Column("im_id", Order = 1)]
        public int IdImage { get; set; }
    }
}
