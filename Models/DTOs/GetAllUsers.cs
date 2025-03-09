namespace SaudeIA.Models.DTOs
{
  public class GetAllUsers
  {
    public Guid Id { get; set; }
    public string Username { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
  }
}
