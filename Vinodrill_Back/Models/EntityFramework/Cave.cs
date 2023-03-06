using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_cave_cav")]
    public partial class Cave
    {
        [Key]
        [ForeignKey("fk_cav_prt")]
        [Column("prt_id", Order = 1)]
        public int IdPartenaire { get; set; }

        [Column("htl_nom")]
        [StringLength(255, ErrorMessage = " nom lenght must be 255 maximum")]
        [Required]
        public string NomPartenaire { get; set; }

        [Column("htl_rue")]
        [StringLength(255, ErrorMessage = " rue lenght must be 255 maximum")]
        [Required]
        public string RuePartenaire { get; set; }

        [Column("htl_cp")]
        [StringLength(5, ErrorMessage = " cp lenght must be 5 maximum")]
        [Required]
        public string CpPartenaire { get; set; }

        [Column("htl_ville")]
        [StringLength(255, ErrorMessage = " ville lenght must be 255 maximum")]
        [Required]
        public string VillePartenaire { get; set; }

        [Column("htl_photo")]
        [StringLength(255, ErrorMessage = " photo lenght must be 255 maximum")]
        [Required]
        public string PhotoPartenaire { get; set; }

        [Column("htl_email")]
        [StringLength(255, ErrorMessage = " email lenght must be 255 maximum")]
        [Required]
        public string EmailPartenaire { get; set; }

        [Column("htl_contact")]
        [StringLength(10, ErrorMessage = " contact lenght must be 10 maximum")]
        [Required]
        public string Contact { get; set; }

        [Column("htl_datail")]
        [Required]
        public string DetailPartenaire { get; set; }

    }
}
