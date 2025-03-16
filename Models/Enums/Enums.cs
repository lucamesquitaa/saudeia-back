using System.ComponentModel;

namespace SaudeIA.Models.Enums
{
  public enum FrequenciaMetaModel
  {
    [Description("Todo dia")]
    Day = 1,
    [Description("Toda semana")]
    Week = 2,
    [Description("Não")]
    None = 3,
  }
  public enum EstadoMetaModel
  {
    [Description("Concluído")]
    Concluido = 1,
    [Description("Em andamento")]
    EmAndamento = 2,
  }
  public enum HorarioMetaModel
  {
    [Description("Manhã")]
    Manha = 1,
    [Description("Tarde")]
    Tarde = 2,
    [Description("Noite")]
    Noite = 3,
    [Description("Dia inteiro")]
    DiaInteiro = 4,
  }
}
