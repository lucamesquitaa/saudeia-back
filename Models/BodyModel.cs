using System.ComponentModel.DataAnnotations;

namespace SaudeIA.Models
{
  public class BodyModel
  {
    [Key]
    public int Id { get; set; }
    public int Idade { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }
  }
}
