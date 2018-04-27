using System.ComponentModel.DataAnnotations;

namespace ConfidentialsWebAPI.Models
{
 
    public class User
    {
      
        [Required]
        [EmailAddress(ErrorMessage ="Le Format de l'email est invalide !")]
        public string Email { get; set; }
   
    }
}
