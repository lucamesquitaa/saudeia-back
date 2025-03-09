using System.ComponentModel;

namespace SaudeIA.Models.Enums
{
  public enum CategoriesMetaModel
  {
    [Description("Alimentação")]
    Alimentacao = 1,
    [Description("Atividade física")]
    AtividadeFisica = 2,
    [Description("Outros")]
    Outros = 3
  }
  public enum EstadoMetaModel
  {
    [Description("Concluído")]
    Concluido = 1,
    [Description("Em andamento")]
    EmAndamento = 2,
  }

}
