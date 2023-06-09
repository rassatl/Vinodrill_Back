﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_paiement_pmt")]
    public partial class Paiement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pmt_idpmt")]
        [Required]
        public int IdPaiement { get; set; }

        [ForeignKey("IdClientPaiement")]
        [Column("usr_id")]
        [Required]
        public int IdClientPaiement { get; set; }

        [Column("pmt_libelle")]
        [StringLength(255, ErrorMessage = "the paiement length must be 255 maximum")]
        [Required]
        public string LibellePaiement { get; set; }

        [Column("pmt_preference")]
        [Required]
        public bool PreferencePaiement { get; set; } = false;

        [InverseProperty(nameof(User.PaiementClientNavigation))]
        public virtual User ClientPaiementNavigation { get; set; } = null!;

        [InverseProperty(nameof(Commande.PaiementCommandeNavigation))]
        public virtual ICollection<Commande> CommandePaiementNavigation { get; set; } = new List<Commande>();
    }
}
