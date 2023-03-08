using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_h_cave_cav")]
    public partial class Cave : Partenaire
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cav_id")]
        public int IdCave { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_prt_cav")]
        [Column("prt_id")]
        public int IdPartenaire { get; set; }

        [InverseProperty(nameof(Partenaire.CavePartenaireNavigation))]
        public virtual Partenaire PartenaireCaveNavigation { get; set; } = null!;

        [InverseProperty(nameof(Visite.CaveVisiteNavigation))]
        public virtual Visite VisiteCaveNavigation { get; set; } = null!;
    }
}
