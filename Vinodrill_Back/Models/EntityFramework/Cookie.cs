using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_cookie_cke")]
    public partial class Cookie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cke_id")]
        [Required]
        public int IdCookie { get; set; }

        [Column("cke_libelle")]
        [StringLength(250, ErrorMessage = "the cookie label length must be 250 maximum")]
        [Required]
        public string LibelleCookie { get; set; }

        [InverseProperty("ClientAdresse")]
        public virtual ICollection<Client>? ClientNavigation { get; set; } = null!;

    }
}
