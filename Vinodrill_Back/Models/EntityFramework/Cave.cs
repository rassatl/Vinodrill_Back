using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_h_cave_cav")]
    public partial class Cave : Partenaire
    {
        [InverseProperty(nameof(Partenaire.CavePartenaireNavigation))]
        public virtual Partenaire PartenaireCaveNavigation { get; set; } = null!;

        [InverseProperty(nameof(Visite.CaveVisiteNavigation))]
        public virtual ICollection<Visite> VisiteCaveNavigation { get; set; } = new List<Visite>();
    }
}
