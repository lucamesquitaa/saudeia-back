using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeIA.Models
{
  public class UserModel
  {
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public virtual ICollection<MetasModel>? Metas { get; set; } = new List<MetasModel>();
    public virtual ICollection<BodyModel>? Body { get; set; } = new List<BodyModel>();
  }
}
