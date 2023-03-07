using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vinodrill_Back.Models.EntityFramework
{
    [Table("t_j_reponseavis_repavs")]
    public partial class ReponseAvi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_avis_repavs")]
        [Column("repavs_id")]
        public int Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("fk_avis_repavs")]
        [Column("repavs_idavis")]
        public int IdAvis { get; set;}

        [InverseProperty("NotesUtilisateur")]
        public virtual Avis RepReponseAvi { get; set; } = null!;

        [InverseProperty("NotesFilm")]
        public virtual Avis Avis { get; set; } = null!;
    }
}
