using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeIA.Models
{
  public class ContatosModel
  {
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey("DetalhesModelId")]
    public Guid DetalhesModelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
  }
}
