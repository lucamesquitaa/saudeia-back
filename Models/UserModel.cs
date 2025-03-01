using System.ComponentModel.DataAnnotations;

namespace SaudeIA.Models
{
  public class UserModel
  {
    [Key]
    public int Id { get; set; }
    public string Username { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
  }
}
