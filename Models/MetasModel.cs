using Mono.TextTemplating;
using SaudeIA.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace SaudeIA.Models
{
  public class MetasModel
  {
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey("UserModelId")]
    public Guid UserModelId { get; set; }
    public FrequenciaMetaModel Frequency { get; set; }
    public HorarioMetaModel Hour { get; set; }
    public string Title { get; set; } = String.Empty;
    public string? Description { get; set; } = String.Empty;
    public EstadoMetaModel State { get; set; }
  }
}
