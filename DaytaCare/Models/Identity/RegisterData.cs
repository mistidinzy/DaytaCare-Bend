using System.ComponentModel.DataAnnotations;

namespace DaytaCare.Models.Identity
{
  public class RegisterData
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
  }

  public class DaycareRegisterData
  {

  }
}
