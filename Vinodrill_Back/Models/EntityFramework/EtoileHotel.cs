using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_etoilehotel_eth")]
    public partial class EtoileHotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("eth_nb")]
        [Range(0, 5)]
        public int NbEtoileHotel { get; set; }

        [InverseProperty(nameof(Hotel.EtoileHotelHotelNavigation))]
        public virtual Hotel HotelEtoileHotelNavigation { get; set; } = null!;
    }
}
