using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_cave_cav")]
    public partial class Cave:Partenaire
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cav_id")]
        public int IdCave { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_prt_cav")]
        [Column("prt_id")]
        public int IdPartenaire { get; set; }

        [Column("prt_nom")]
        [StringLength(255, ErrorMessage = " nom lenght must be 255 maximum")]
        [Required]
        public string NomPartenaire { get; set; }

        [Column("prt_rue")]
        [StringLength(255, ErrorMessage = " rue lenght must be 255 maximum")]
        [Required]
        public string RuePartenaire { get; set; }

        [Column("prt_cp")]
        [StringLength(5, ErrorMessage = " cp lenght must be 5 maximum")]
        [Required]
        public string CpPartenaire { get; set; }

        [Column("prt_ville")]
        [StringLength(255, ErrorMessage = " ville lenght must be 255 maximum")]
        [Required]
        public string VillePartenaire { get; set; }

        [Column("prt_photo")]
        [StringLength(255, ErrorMessage = " photo lenght must be 255 maximum")]
        [Required]
        public string PhotoPartenaire { get; set; }

        [Column("prt_email")]
        [StringLength(255, ErrorMessage = " email lenght must be 255 maximum")]
        [Required]
        public string EmailPartenaire { get; set; }

        [Column("prt_contact")]
        [StringLength(10, ErrorMessage = " contact lenght must be 10 maximum")]
        [Required]
        public string Contact { get; set; }

        [Column("prt_datail", TypeName = "text")]
        [Required]
        public string DetailPartenaire { get; set; }

    }
}
