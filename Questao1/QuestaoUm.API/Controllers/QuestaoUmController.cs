using AutoMapper;
using QuestaoUm.API.Entities;
using QuestaoUm.API.Models;
using QuestaoUm.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QuestaoUm.API.Controllers
{
    [Route("api/dev-conta")]
    [ApiController]
    public class QuestaoUmController : ControllerBase
    {
        private readonly QuestaoUmDbContext _context;
        private readonly IMapper _mapper;
        private const decimal taxa = 3.50M;
        public QuestaoUmController(QuestaoUmDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todas as contas correntes
        /// </summary>
        /// <returns>Coleção de contas correntes</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var contasCorrente = _context.ContasCorrente
                                         .Include(d => d.Lancamentos)
                                         .ToList();

            var viewModel = _mapper.Map<List<ContaCorrenteViewModel>>(contasCorrente);

            return Ok(viewModel);
        }

        /// <summary>
        /// Cadastrar uma conta corrente
        /// </summary>
        /// <remarks>
        /// {"contaId": "string",  "nomeTitular": "string",  "valorInicial": 0}
        /// </remarks>
        /// <param name="input">Dados da conta corrente</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(ContaCorrenteInputModel input)
        {
            decimal saldoAtual = input.ValorInicial.GetValueOrDefault(0.00M);

            var contasCorrente = _mapper.Map<ContaCorrente>(input);
            contasCorrente.SaldoAtual = input.ValorInicial;

            _context.ContasCorrente.Add(contasCorrente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = contasCorrente.ContaId }, contasCorrente);
        }

        /// <summary>
        /// Alterar uma conta
        /// </summary>
        /// <remarks>
        /// {"contaId": "string",  "nomeTitular": "string"}
        /// </remarks>
        /// <param name="input">Dados da conta</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(ContaCorrenteUpdateModel input)
        {
            var contaCorrente = _context.ContasCorrente
                .SingleOrDefault(d => d.ContaId == input.ContaId);

            if (contaCorrente == null)
                return NotFound("Conta não cadastrada");

            _mapper.Map(input, contaCorrente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = contaCorrente.ContaId }, contaCorrente);
        }


        /// <summary>
        /// Obter uma conta
        /// </summary>
        /// <remarks>
        /// {"contaId": "string"}
        /// </remarks>
        /// <param name="id">Identificador da conta corrente</param>
        /// <returns>Dados da conta corrente</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            var contasCorrente = _context.ContasCorrente
                .Include(de => de.Lancamentos)
                .SingleOrDefault(d => d.ContaId == id);

            if (contasCorrente == null)
                return NotFound("Conta nao cadastrada");

            var viewModel = _mapper.Map<ContaCorrenteViewModel>(contasCorrente);

            return Ok(viewModel);
        }

        /// <summary>
        /// Cadastrar um lancamento
        /// </summary>
        /// <remarks>
        /// {"debitoCredito": "C","valor": 90,"contaId": "CONTA UM"}
        /// </remarks>
        /// <param name="input">Dados do lancamento</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost("Lancamento")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Lancamento(LancamentoInputModel input)
        {
            var lancamento = _mapper.Map<Lancamento>(input);

            var contaCorrente = _context.ContasCorrente.SingleOrDefault(c => c.ContaId == lancamento.ContaId);

            if (contaCorrente == null)
                return NotFound("Conta Corrente nao encontrada");

            decimal saldoAtual = contaCorrente.SaldoAtual.GetValueOrDefault(0.00M);
            lancamento.SaldoAntes = saldoAtual;

            if (lancamento.DebitoCredito == "C")
                lancamento.SaldoApos = ((saldoAtual + lancamento.Valor));
            else
            {
                lancamento.SaldoApos = (saldoAtual - (lancamento.Valor + taxa));
                lancamento.Valor += taxa;
            }

            contaCorrente.SaldoAtual = lancamento.SaldoApos;
            _context.ContasCorrente.Update(contaCorrente);

            _context.Lancamentos.Add(lancamento);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetByIdLancamento), new { id = lancamento.LancamentoId }, lancamento);
        }

        /// <summary>
        /// Obter um lancamento
        /// </summary>
        /// <remarks>
        /// {"Id": "int"}
        /// </remarks>
        /// <param name="id">Identificador do lancamento</param>
        /// <returns>Dados do lancamento</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("GetByIdLancamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByIdLancamento(int id)
        {
            var lancamento = _context.Lancamentos
                .SingleOrDefault(d => d.LancamentoId == id);

            if (lancamento == null)
                return NotFound();

            var viewModel = _mapper.Map<LancamentoViewModel>(lancamento);

            return Ok(viewModel);
        }

        /// <summary>
        /// Obter saldo da conta corrente
        /// </summary>
        /// <remarks>
        /// {"contaId": "string"}
        /// </remarks>
        /// <param name="id">Identificador da conta corrente</param>
        /// <returns>Dados da conta corrente</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("GetSaldoByContaId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSaldoByContaId(string id)
        {
            var contasCorrente = _context.ContasCorrente
                .SingleOrDefault(d => d.ContaId == id);

            if (contasCorrente == null)
                return NotFound("Conta nao cadastrada");

            var viewModel = _mapper.Map<ContaCorrenteSaldoViewModel>(contasCorrente);

            return Ok(viewModel);
        }
    }
}
