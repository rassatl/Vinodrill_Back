using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_client_clt")]
    public partial class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("clt_id")]
        [Required]
        public int IdClient { get; set; }

        [ForeignKey("fk_avis_clt")]
        [Column("avis_idavis", Order = 0)]
        [Required]
        public int IdAvisClient { get; set; }

        [ForeignKey("fk_cb_clt")]
        [Column("cb_idcb", Order = 1)]
        [Required]
        public int IdCbClient { get; set; }

        [Column("clt_nom")]
        [StringLength(255, ErrorMessage = "the client name must be 255 maximum")]
        [Required]
        public string NomClient { get; set; }

        [Column("clt_prenom")]
        [StringLength(255, ErrorMessage = "the client first name must be 255 maximum")]
        [Required]
        public string PrenomClient { get; set; }

        [Column("clt_datenaissance", TypeName = "date")]
        [Required]
        public DateTime DateNaissanceClient { get; set; }

        [Column("clt_sexe")]
        [RegularExpression(@"^[0-9]{1}$", ErrorMessage = "sexe length must be 1 maximum")]
        [Required]
        public string SexeClient { get; set; }

        [Column("clt_motdepasse")]
        [StringLength(255, ErrorMessage = "motdepasse length must be 255 maximum")]
        [Required]
        public string MotDePasseClient { get; set; }

        [Column("clt_email")]
        [EmailAddress]
        [StringLength(255, ErrorMessage = "email length must be 255 maximum")]
        [Required]
        public string EmailClient { get; set; }

        [InverseProperty(nameof(Cb.ClientCbNavigation))]
        public virtual ICollection<Cb> CbClientNavigation { get; set; } = null!;

        [InverseProperty(nameof(Adresse.ClientAdresseNavigation))]
        public virtual Adresse AdresseClientNavigation { get; set; } = null!;

        [InverseProperty(nameof(Paiement.ClientPaiementNavigation))]
        public virtual Paiement PaiementClientNavigation { get; set; } = null!;

        [InverseProperty(nameof(Commande.ClientCommandeNavigation))]
        public virtual Commande CommandeClientNavigation { get; set; } = null!;

        [InverseProperty(nameof(Avis.ClientAvisNavigation))]
        public virtual Avis AvisClientNavigation { get; set; } = null!;

        [InverseProperty(nameof(Sejour.ClientSejourNavigation))]
        public virtual ICollection<Sejour> SejourClientNavigation { get; set; } = null;
    }
}
