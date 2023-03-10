using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_h_societe_sct")]
    public partial class Societe : Partenaire
    {
/*
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_prt_sct")]
        [Column("prt_id", Order = 1)]
        public int IdPartenaire { get; set; }*/

        [ForeignKey("IdTypeActivite")]
        [Column("tac_id", Order = 0)]
        public int IdTypeActivite { get; set; }

       

        [InverseProperty(nameof(Partenaire.SocietePartenaireNavigation))]
        public virtual Partenaire PartenaireSocieteNavigation { get; set; } = null!;

        [InverseProperty(nameof(Activite.SocieteActiviteNavigation))]
        public virtual ICollection<Activite> ActiviteSocieteNavigation { get; set; } = new List<Activite>();

        [InverseProperty(nameof(TypeActivite.SocieteTypeActiviteNavigation))]
        public virtual TypeActivite TypeActiviteSocieteNavigation { get; set; } = null!;


    }
}
