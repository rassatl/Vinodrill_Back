using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_h_hotel_htl")]
    public partial class Hotel : Partenaire
    {

        [ForeignKey("NbEtoileHotel")]
        [Column("ect_nb", Order = 0)]
        [Range(0, 5)]
        public int NbEtoileHotel { get; set; }

        [InverseProperty(nameof(Partenaire.HotelPartenaireNavigation))]
        public virtual Partenaire PartenaireHotelNavigation { get; set; } = null!;

        [InverseProperty(nameof(EtoileHotel.HotelEtoileHotelNavigation))]
        public virtual EtoileHotel EtoileHotelHotelNavigation { get; set; } = null!;

        [InverseProperty(nameof(Hebergement.HotelHebergementNavigation))]
        public virtual ICollection<Hebergement> HebergementHotelNavigation { get; set; } = new List<Hebergement>();

    }
}
