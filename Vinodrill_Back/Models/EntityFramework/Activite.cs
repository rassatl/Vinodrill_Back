using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_activite_act")]
    public partial class Activite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [ForeignKey("IdPartenaire")]
        [Column("prt_id")]
        public int IdPartenaire { get; set; }

        [Column("act_libelle")]
        [StringLength(255, ErrorMessage = "libelle must be 255 maximum")]
        public string LibelleActivite { get; set; }

        [Column("act_description", TypeName = "text")]
        public string DescriptionActivite { get; set; }

        [Column("act_ruerdv")]
        [StringLength(255, ErrorMessage = "rue must be 255 maximum")]
        public string RueRdv { get; set; }

        [Column("act_cprdv", TypeName = "char(5)")]
        public string CpRdv { get; set; }

        [Column("act_villerdv")]
        [StringLength(255, ErrorMessage = "ville must be 255 maximum")]
        public string VilleRdv { get; set; }

        [Column("act_horaire")]
        public TimeOnly HoraireActivite { get; set; }

        [InverseProperty(nameof(Societe.ActiviteSocieteNavigation))]
        public virtual Societe? SocieteActiviteNavigation { get; set; } = null!;

        [InverseProperty(nameof(Effectue.ActiviteEffectueNavigation))]
        public virtual ICollection<Effectue> EffectueActiviteNavigation { get; set; } = new List<Effectue>();
    }
}
