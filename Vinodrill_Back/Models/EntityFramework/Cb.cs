using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_e_cb_cb")]
    public partial class Cb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cb_idcb")]
        [Required]
        public int IdCb { get; set; }

        [Column("cb_cvc")]
        [StringLength(255, ErrorMessage = "the length of the cvc must be 255 maximum")]
        [Required]
        public string CvcCb { get; set; }

        [Column("cb_code")]
        [StringLength(255, ErrorMessage = "the length of the code must be 255 maximum")]
        [Required]
        public string CodeCb { get; set; }

        [Column("cb_anneeexp")]
        [StringLength(255, ErrorMessage = "the length of the expAnnee must be 255 maximum")]
        [Required]
        public string AnneeExpCb { get; set; }

        [Column("cb_moisexp")]
        [StringLength(255, ErrorMessage = "the length of the expMonth must be 255 maximum")]
        [Required]
        public string MoisExpCb { get; set; }

        [InverseProperty(nameof(Client.CbClientNavigation))]
        public virtual Client ClientCbNavigation { get; set; } = null;

    }
}
