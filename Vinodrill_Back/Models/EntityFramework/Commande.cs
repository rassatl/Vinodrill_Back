﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_commande_cmd")]
    public partial class Commande
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cmd_id")]
        public int RefCommande { get; set; }

        [ForeignKey("fk_clt_cmd")]
        [Column("cmd_idclient", Order = 0)]
        [Required]
        public int IdClient { get; set; }

        [ForeignKey("fk_pmt_cmd")]
        [Column("cmd_idpaiement", Order = 1)]
        [Required]
        public int IdPaiement { get; set; }

        [Column("cmd_datecommande", TypeName = "date")]
        [Required]
        public DateTime DateCommande { get; set; }


        [Column("cmd_prixcommande")]
        [Required]
        public decimal PrixCommande { get; set; }

        [Column("cmd_quantite")]
        [Required]
        public int Quantite { get; set; }

        [Column("cmd_message", TypeName = "text")]
        [Required]
        public string Message { get; set; }

        [Column("cmd_cheminfacture", TypeName = "text")]
        [Required]
        public string CheminFacture { get; set; }

        [Column("cmd_estcheque")]
        [Required]
        public bool EstCheque { get; set; }

        [InverseProperty(nameof(BonCommande.CommandeBonCommandeNavigation))]
        public virtual BonCommande BonCommandeCommandeNavigation { get; set; } = null!;

        [InverseProperty(nameof(BonReduction.CommandeBonReductionNavigation))]
        public virtual BonReduction BonReductionCommandeNavigation { get; set; } = null!;

        [InverseProperty(nameof(Client.CommandeClientNavigation))]
        public virtual ICollection<Client> ClientCommandeNavigation { get; set; } = null;

        [InverseProperty(nameof(Paiement.CommandePaiementNavigation))]
        public virtual ICollection<Paiement> PaiementCommandeNavigation { get; set; } = null;

        //[InverseProperty(nameof(Reservation.CommandeReservationNavigation))]
        //public virtual ICollection<Reservation> ReservationCommandeNavigation {get; set; } = null!;

    }
}
