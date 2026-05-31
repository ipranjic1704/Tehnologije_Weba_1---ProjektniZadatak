using System.ComponentModel.DataAnnotations;

namespace ProjektniZadatak.DataTransferObjects
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lozinka je obavezna")]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "Lozinka mora imati barem 8 znakova")]
        public string Password { get; set; } = string.Empty;
    }
}
