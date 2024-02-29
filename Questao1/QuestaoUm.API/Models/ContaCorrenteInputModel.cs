namespace QuestaoUm.API.Models;

public class ContaCorrenteInputModel
{
    public string ContaId { get; set; }
    public string NomeTitular { get; set; }

    public decimal? ValorInicial { get; set; }
}
