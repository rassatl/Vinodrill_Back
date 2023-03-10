using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_etoilerestaurant_etr")]
    public partial class EtoileRestaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("etr_nb")]
        [Range(0, 3)]
        public int NbEtoileRestaurant { get; set; }

        [InverseProperty(nameof(Restaurant.EtoileRestaurantRestaurantNavigation))]
        public virtual ICollection<Restaurant> RestaurantEtoileRestaurantRestaurantNavigation { get; set; } = new List<Restaurant>();
    }
}