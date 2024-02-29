namespace QuestaoUm.API.Entities
{
    public class Lancamento
    {
        public int LancamentoId { get; set; }

        public string DebitoCredito { get; set; }

        public decimal Valor { get; set; }

        public decimal SaldoAntes { get; set; }
        public decimal SaldoApos { get; set; }

        public DateTime DataTransacao { get; set; } = DateTime.Now;

        public string ContaId {  get; set; }

    }
}
