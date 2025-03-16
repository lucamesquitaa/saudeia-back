using SaudeIA.Models.Enums;

namespace SaudeIA.Models.DTOs
{
  public class MetasDTO
  {
    public string UserId { get; set; } = String.Empty;
    public int? Frequency { get; set; }
    public int? Hour { get; set; }
    public string Title { get; set; } = String.Empty;
    public string? Description { get; set; }
  }
}
