namespace QuestaoUm.API.Entities
{
    public class ContaCorrente
    {
        public ContaCorrente()
        {
            Lancamentos = new List<Lancamento>();
        }

        public string ContaId { get; set; }
        public string NomeTitular { get; set; }

        public decimal? ValorInicial { get; set;}

        public decimal? SaldoAtual { get; set; }

        public List<Lancamento> Lancamentos { get; set; }

        public void Update(string nomeTitular)
        {
            NomeTitular = nomeTitular;
        }
    }
}
