using System.ComponentModel.DataAnnotations;

namespace AuthenticationWebAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "Le Format de l'email est invalide !")]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
