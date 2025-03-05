using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeIA.Models
{
  public class BodyModel
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    public int Idade { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }
  }
}
