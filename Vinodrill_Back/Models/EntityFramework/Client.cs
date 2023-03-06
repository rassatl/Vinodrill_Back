using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_client_clt")]
    public partial class Adresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("clt_id")]
        [Required]
        public int IdClient { get; set; }

        [Column("clt_avis")]
        [Required]
        public int IdAvisClient { get; set; }

        [Column("adr_rueadresse")]
        [Required]
        public int IdCbClient { get; set; }

        [Column("adr_ville")]
        [StringLength(250, ErrorMessage = "the length of the city must be 250 maximum")]
        [Required]
        public string NomClient { get; set; }

        [Column("adr_cp")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "postcode length must be 5 maximum")]
        [Required]
        public string CodePostal { get; set; }

        [Column("adr_pays")]
        [StringLength(5, ErrorMessage = "country length should be 25 maximum")]
        [Required]
        public string Pays { get; set; }

        [InverseProperty("ClientAdresse")]
        public virtual ICollection<Client>? ClientNavigation { get; set; } = null!;

    }
}
