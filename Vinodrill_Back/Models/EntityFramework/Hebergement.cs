﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_hebergement_hbg")]
    public partial class Hebergement
    {

        [ForeignKey("IdPartenaire")]
        [Column("prt_id")]
        public int IdPartenaire { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("hbg_id")]
        public int IdHebergement { get; set; }

        [Column("hbg_libelle")]
        [StringLength(255, ErrorMessage = " libelle lenght must be 255 maximum")]
        [Required]
        public string LibelleHebergement { get; set; }

        [Column("hbg_description", TypeName = "text")]
        [Required]
        public string DescriptionHebergement { get; set; }

        [Column("hbg_nbchambre")]
        [Required]
        public int NbChambre { get; set; }

        [Column("hbg_horaire")]
        [StringLength(255, ErrorMessage = " horaire lenght must be 255 maximum")]
        [Required]
        public TimeOnly HoraireHebergement { get; set; }

        [InverseProperty(nameof(Hotel.HebergementHotelNavigation))]
        public virtual Hotel HotelHebergementNavigation { get; set; } = null!;

        [InverseProperty(nameof(Etape.HebergementEtapeNavigation))]
        public virtual ICollection<Etape> EtapeHebergementNavigation { get; set; } = new List<Etape>();
    }
}
