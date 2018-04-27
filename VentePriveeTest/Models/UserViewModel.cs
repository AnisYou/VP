using System.ComponentModel.DataAnnotations;

namespace VentePriveeTest.Models
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adresse email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

    }
}
