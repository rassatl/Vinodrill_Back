using System.ComponentModel.DataAnnotations;

namespace Vinodrill_Back.Models.Auth
{
    public class RegisterModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Veuillez renseigner un e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner un mot de passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner une confirmation de mot de passe")]
        [Compare("Password", ErrorMessage = "Votre mot de passe et sa confirmation ne correspondent pas")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner un prénom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner un nom")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner une date de naissance")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner un genre")]
        [StringLength(1, ErrorMessage = "Votre genre doit être M ou F")]
        public string Gender { get; set; }
    }
}
