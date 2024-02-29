namespace QuestaoUm.API.Models;

public class ContaCorrenteViewModel
{
    public string ContaId { get; set; }
    public string NomeTitular { get; set; }
    public decimal? ValorInicial { get; set; }
    public List<LancamentoViewModel> Lancamentos { get; set; }
}
