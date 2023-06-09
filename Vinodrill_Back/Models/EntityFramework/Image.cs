﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_image_img")]
    public partial class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("img_id")]
        public int IdImage { get; set; }

        [Column("img_libelle")]
        [StringLength(255, ErrorMessage = "the length of the libelle must be 255 maximum")]
        [Required]
        public string LienImage { get; set; }

        [InverseProperty(nameof(ImageAvis.ImageImageAvisNavigation))]
        public virtual ICollection<ImageAvis> ImageAvisImageNavigation { get; set; } = new List<ImageAvis>();
    }
}
