using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_user_usr")]
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("usr_id")]
        [Required]
        public int IdClient { get; set; }

        [ForeignKey("CbClientNavigation")]
        [Column("cb_idcb", Order = 1)]
        public int? IdCbClient { get; set; }

        [Column("usr_nom")]
        [StringLength(255, ErrorMessage = "the client name must be 255 maximum")]
        [Required]
        public string NomClient { get; set; }

        [Column("usr_prenom")]
        [StringLength(255, ErrorMessage = "the client first name must be 255 maximum")]
        [Required]
        public string PrenomClient { get; set; }

        [Column("usr_datenaissance", TypeName = "date")]
        [Required]
        public DateTime DateNaissanceClient { get; set; }

        [Column("usr_sexe")]
        [RegularExpression(@"^[A-Z]{1}$", ErrorMessage = "sexe length must be 1 maximum")]
        [Required]
        public string SexeClient { get; set; }

        [Column("usr_email")]
        [EmailAddress]
        [StringLength(255, MinimumLength = 6, ErrorMessage = " email lenght must be 255 maximum")]
        [Required]
        public string EmailClient { get; set; }

        [Column("usr_motdepasse")]
        [Required]
        public string MotDePasse { get; set; }

        [Column("usr_role")]
        public string? UserRole { get; set; }

        [InverseProperty(nameof(Cb.ClientCbNavigation))]
        public virtual Cb? CbClientNavigation { get; set; } = null;

        [InverseProperty(nameof(Adresse.ClientAdresseNavigation))]
        public virtual ICollection<Adresse> AdresseClientNavigation { get; set; } = new List<Adresse>();

        [InverseProperty(nameof(Paiement.ClientPaiementNavigation))]
        public virtual ICollection<Paiement> PaiementClientNavigation { get; set; } = new List<Paiement>();

        [InverseProperty(nameof(Commande.ClientCommandeNavigation))]
        public virtual ICollection<Commande> CommandeClientNavigation { get; set; } = new List<Commande>();

        [InverseProperty(nameof(Avis.ClientAvisNavigation))]
        public virtual ICollection<Avis> AvisClientNavigation { get; set; } = new List<Avis>();

        [InverseProperty(nameof(AvisPartenaire.ClientAvisPartenaireNavigation))]
        public virtual ICollection<AvisPartenaire> AvisPartenaireClientNavigation { get; set; } = new List<AvisPartenaire>();
    }
}
