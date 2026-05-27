using Microsoft.AspNetCore.Identity;

namespace ProjektniZadatak.Model
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
