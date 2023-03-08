using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_typevisite_tvs")]
    public partial class TypeVisite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tvs_id")]
        [Required]
        public int IdTypeVisite { get; set; }

        [Column("tvs_libelle")]
        [StringLength(250, ErrorMessage = "the libelle type visite must be 255 maximum")]
        [Required]
        public string LibelleTypeVisite { get; set; }

        [InverseProperty(nameof(Visite.TypeVisiteVisiteNavigation))]
        public virtual ICollection<Visite> VisiteTypeVisiteNavigation { get; set; } = new List<Visite>();
    }
}
