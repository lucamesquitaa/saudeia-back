using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeIA.Models
{
  public class FotosDetalhesModel
  {
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [ForeignKey("DetalhesModelId")]
    public Guid DetalhesModelId { get; set; }
    public string Alt { get; set; } = String.Empty;
    public string Url { get; set; } = String.Empty;
  }
}
