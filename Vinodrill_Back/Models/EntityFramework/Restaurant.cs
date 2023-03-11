using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_h_restaurant_res")]
    public partial class Restaurant : Partenaire
    {
        [ForeignKey(nameof(TypeCuisineCuisineNavigation))]
        [Column("tcu_id")]
        public int IdTypeCuisineCuisine { get; set; }

        [ForeignKey(nameof(EtoileRestaurantRestaurantNavigation))]
        [Column("etr_nb")]
        public int NbEtoileRestaurantRestaurant { get; set; }

        [Column("res_specialite")]
        [StringLength(255, ErrorMessage = "the specialite must be 255 maximum")]
        public string? SpecialiteRestaurant { get; set; }

        [InverseProperty(nameof(EtoileRestaurant.RestaurantEtoileRestaurantRestaurantNavigation))]
        public virtual EtoileRestaurant EtoileRestaurantRestaurantNavigation { get; set; } = null!;

        [InverseProperty(nameof(TypeCuisine.RestaurantTypeCuisineCuisineNavigation))]
        public virtual TypeCuisine TypeCuisineCuisineNavigation { get; set; } = null!;
    }
}