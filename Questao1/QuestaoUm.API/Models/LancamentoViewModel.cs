namespace QuestaoUm.API.Models;

public class LancamentoViewModel
{
    public int LancamentoId { get; set; }

    public string DebitoCredito { get; set; }

    public decimal Valor { get; set; }
    
    public DateTime DataTransacao { get; set; }

    public string ContaId { get; set; }
}
