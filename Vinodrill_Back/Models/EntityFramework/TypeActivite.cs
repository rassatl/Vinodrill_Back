using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_typeactivite_tac")]
    public partial class TypeActivite
    {
        [Key]
        [Column("tac_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTypeActivite {get; set;}

        [Column("tac_libelletype")]
        [Required]
        [StringLength(250)]
        public string LibelleType {get; set;}

        [InverseProperty(nameof(Societe.TypeActiviteSocieteNavigation))]
        public virtual ICollection<Societe> SocieteTypeActiviteNavigation { get; set; } = new List<Societe>();
    }
}
