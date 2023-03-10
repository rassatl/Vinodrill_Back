using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_destination_dst")]
    public partial class Destination
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("dst_id")]
        [Required]
        public int IdDestination { get; set; }

        [Column("dst_libelle")]
        [Required]
        [StringLength(255, ErrorMessage = "the length of the destination must be 255 maximum")]
        public string LibelleDestination { get; set; }

        [Column("dst_description", TypeName = "text")]
        [Required]
        public string DescriptionDestination { get; set; }

        [InverseProperty(nameof(Sejour.DestinationSejourNavigation))]
        public virtual ICollection<Sejour> SejourDestinationNavigation { get; set; } = new List<Sejour>();
    }
}
