﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_partenaire_prt")]
    public partial class Partenaire
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("prt_id")]
        public int IdPartenaire { get; set; }

        [Column("prt_nom")]
        [StringLength(255, ErrorMessage = " nom lenght must be 255 maximum")]
        [Required]
        public string NomPartenaire { get; set; }

        [Column("prt_rue")]
        [StringLength(255, ErrorMessage = " rue lenght must be 255 maximum")]
        [Required]
        public string RuePartenaire { get; set; }

        [Column("prt_cp")]
        [StringLength(5, ErrorMessage = " cp lenght must be 5 maximum")]
        [Required]
        public string CpPartenaire { get; set; }

        [Column("prt_ville")]
        [StringLength(255, ErrorMessage = " ville lenght must be 255 maximum")]
        [Required]
        public string VillePartenaire { get; set; }

        [Column("prt_photo")]
        [StringLength(255, ErrorMessage = " photo lenght must be 255 maximum")]
        [Required]
        public string? PhotoPartenaire { get; set; }

        [Column("prt_email")]
        [EmailAddress]
        [StringLength(255, MinimumLength = 6, ErrorMessage = " email lenght must be 255 maximum")]
        [Required]
        public string EmailPartenaire { get; set; }

        [Column("prt_contact", TypeName = "char(10)")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Contact lenght must be 10 maximum, starting by 0 and only with numbers")]
        [Required]
        public string Contact { get; set; }

        [Column("prt_detailpartenaire", TypeName = "text")]
        [Required]
        public string DetailPartenaire { get; set; }

        [InverseProperty(nameof(Societe.PartenaireSocieteNavigation))]
        public virtual ICollection<Societe> SocietePartenaireNavigation { get; set; } = new List<Societe>();

        [InverseProperty(nameof(Cave.PartenaireCaveNavigation))]
        public virtual ICollection<Cave> CavePartenaireNavigation { get; set; } = new List<Cave>();

        [InverseProperty(nameof(Hotel.PartenaireHotelNavigation))]
        public virtual ICollection<Hotel> HotelPartenaireNavigation { get; set; } = new List<Hotel>();

        [InverseProperty(nameof(AvisPartenaire.PartenaireAvisPartenaireNavigation))]
        public virtual ICollection<AvisPartenaire> AvisPartenairePartenaireNavigation { get; set; } = new List<AvisPartenaire>();
    }
}
