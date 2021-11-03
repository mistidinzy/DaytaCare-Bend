using System.ComponentModel.DataAnnotations;

namespace DaytaCare.Models.Identity
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
