using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_imageavis_ima")]
    public partial class ImageAvis
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdAvis")]
        [Column("avi_id", Order = 0)]
        public int IdAvis { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdImage")]
        [Column("im_id", Order = 1)]
        public int IdImage { get; set; }

        [InverseProperty(nameof(Avis.ImageAvisAvisNavigation))]
        public virtual Avis AvisImageAvisNavigation { get; set; } = null!;

        [InverseProperty(nameof(Image.ImageAvisImageNavigation))]
        public virtual Image ImageImageAvisNavigation { get; set; } = null!;
    }
}
