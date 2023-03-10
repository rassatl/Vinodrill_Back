using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_adresse_adr")]
    public partial class Adresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("adr_id")]
        [Required]
        public int IdAdresse { get; set; }

        [ForeignKey("IdClient")]
        [Column("clt_idclient")]
        [Required]
        public int IdClient { get; set; }

        [Column("adr_libelle")]
        [StringLength(250, ErrorMessage = "the length of the caption must be 250 maximum")]
        [Required]
        public string LibelleAdresse { get; set; }

        [Column("adr_rueadresse")]
        [StringLength(250, ErrorMessage = "the length of the address must be 250 maximum")]
        [Required]
        public string RueAdresse { get; set; }

        [Column("adr_ville")]
        [StringLength(250, ErrorMessage = "the length of the city must be 250 maximum")]
        [Required]
        public string VilleAdresse { get; set; }

        [Column("adr_cp")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "postcode length must be 5 maximum")]
        [Required]
        public string CodePostalAdresse { get; set; }

        [Column("adr_pays")]
        [StringLength(255, ErrorMessage = "country length should be 255 maximum")]
        [Required]
        public string PaysAdresse { get; set; }

        [InverseProperty(nameof(Client.AdresseClientNavigation))]
        public virtual Client ClientAdresseNavigation { get; set; } = null!;


    }
}
