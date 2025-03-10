using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeIA.Models
{
  public class BodyModel
  {
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey("UserModelId")]
    public Guid UserModelId { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }
    public double IMC { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
  }
}
