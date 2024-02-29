namespace QuestaoUm.API.Models;

public class ContaCorrenteSaldoViewModel
{
    public string ContaId { get; set; }
    public string NomeTitular { get; set; }

    public decimal? ValorInicial { get; set; }

    public decimal? SaldoAtual { get; set; }

}

