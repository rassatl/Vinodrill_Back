using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_type_cuisine_tcu")]
    public partial class TypeCuisine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tcu_id")]
        public int IdTypeCuisine { get; set; }

        [Column("tcu_libelle")]
        [StringLength(255, ErrorMessage = "the libelle must be 255 maximum")]
        public string LibelleTypeCuisine { get; set; }

        [InverseProperty(nameof(Restaurant.TypeCuisineCuisineNavigation))]
        public virtual ICollection<Restaurant> RestaurantTypeCuisineCuisineNavigation { get; set; } = new List<Restaurant>();

    }
}