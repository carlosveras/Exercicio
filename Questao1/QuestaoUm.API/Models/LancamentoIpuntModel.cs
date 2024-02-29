using System.ComponentModel.DataAnnotations;

namespace QuestaoUm.API.Models;

public class LancamentoInputModel
{
    [RegularExpression("^[DC]$", ErrorMessage = "O campo DebitoCredito só aceita D ou C")]
    public string DebitoCredito { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "O campo {0} deve ser maior ou igual a 0.")]
    public decimal Valor { get; set; }

    public string ContaId { get; set; }
}
