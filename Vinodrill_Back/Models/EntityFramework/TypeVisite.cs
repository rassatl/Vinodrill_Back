using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_typevisite_tvst")]
    public partial class TypeVisite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tvst_id")]
        [Required]
        public int IdTypeVisite { get; set; }

        [Column("tvst_libelle")]
        [StringLength(250, ErrorMessage = "the libelle type visite must be 255 maximum")]
        [Required]
        public string LibelleTypeVisite { get; set; }
    }
}
