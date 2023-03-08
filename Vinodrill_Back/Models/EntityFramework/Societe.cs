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

        [ForeignKey("fk_act_sct")]
        [Column("act_id", Order = 0)]
        public int IdTypeActivite { get; set; }

       

        [InverseProperty(nameof(Partenaire.SocietePartenaireNavigation))]
        public virtual ICollection<Partenaire> PartenaireSocieteNavigation { get; set; } = new List<Partenaire>();

        [InverseProperty(nameof(Activite.SocieteActiviteNavigation))]
        public virtual ICollection<Activite> ActiviteSocieteNavigation { get; set; } = new List<Activite>();

        [InverseProperty(nameof(TypeActivite.SocieteTypeActiviteNavigation))]
        public virtual TypeActivite TypeActiviteSocieteNavigation { get; set; } = null!;


    }
}
