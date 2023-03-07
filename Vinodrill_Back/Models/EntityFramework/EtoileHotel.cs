using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_etoilehotel_etht")]
    public partial class EtoileHotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("etht_nb")]
        [Range(0, 5)]
        public int NbEtoileHotel { get; set; }

        [InverseProperty("EtoileHotHotel")]
        public virtual Hotel HotelEtoileHot { get; set; } = null!;
    }
}
