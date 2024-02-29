using QuestaoCinco.Application.DTOs;
using QuestaoCinco.Application.Interfaces;
using QuestaoCinco.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace QuestaoCinco.Api.Controllers
{
    #region atual
    //[ApiController]
    //[Route("[controller]")]
    //public class WeatherForecastController : ControllerBase
    //{
    //    private static readonly string[] Summaries = new[]
    //    {
    //        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //    };

    //    private readonly ILogger<WeatherForecastController> _logger;

    //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet]
    //    public IEnumerable<WeatherForecast> Get()
    //    {
    //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //        {
    //            Date = DateTime.Now.AddDays(index),
    //            TemperatureC = Random.Shared.Next(-20, 55),
    //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //    }
    //}
    #endregion

    [ApiController]
    [Route("api/[controller]")]
    public class QuestaoCincoController : ControllerBase
    {
        private readonly IContaCorrenteService _contaCorrenteService;
        private readonly ILancamentoService _lancamentoService;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly ILancamentoRepository _lancamentoRepository;

        private readonly IWebHostEnvironment _environment;
        private readonly IMediator _mediatr;

        public QuestaoCincoController(IContaCorrenteService contaCorrenteService,
                                      ILancamentoService lancamentoService,
                                      IWebHostEnvironment environment,
                                      IContaCorrenteRepository contaCorrenteRepository,
                                      ILancamentoRepository lancamentoRepository,
                                      IMediator mediatr)
        {
            _contaCorrenteService = contaCorrenteService;
            _lancamentoService = lancamentoService;
            _environment = environment;
            _contaCorrenteRepository = contaCorrenteRepository;
            _lancamentoRepository = lancamentoRepository;
            _mediatr = mediatr;
        }

        /// <summary>
        /// Obter todas as contas correntes
        /// </summary>
        /// <returns>Coleção de contas correntes</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                return Ok(await _contaCorrenteService.GetContas());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Obter uma conta e seus lancamentos
        /// </summary>
        /// <remarks>
        /// {"contaId": "string"}
        /// </remarks>
        /// <param name="id">Identificador da conta corrente</param>
        /// <returns>Dados da conta corrente e lancamentos</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(string id)
        {
            var contasCorrente = await _contaCorrenteService.GetById(id);

            if (contasCorrente == null)
                return NotFound("Conta nao cadastrada");

            return Ok(contasCorrente);
        }

        /// <summary>
        /// Alterar uma conta
        /// </summary>
        /// <remarks>
        /// {"contaId": "string",  "nomeTitular": "string"}
        /// </remarks>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="400">Bad Request</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(ContaCorrenteAlteraDTO contaCorrenteDto)
        {
            if (ModelState.IsValid)
            {
                var contaCorrente = await _contaCorrenteService.Update(contaCorrenteDto);

                if (contaCorrente == null)
                    return NotFound("Conta não cadastrada");

                return CreatedAtAction(nameof(QuestaoCincoController.GetById), new { id = contaCorrente.ContaId }, contaCorrente);
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Cadastrar uma conta corrente
        /// </summary>
        /// <remarks>
        /// {"contaId": "string",  "nomeTitular": "string",  "valorInicial": 0}
        /// </remarks>
        /// <param name="contaCorrenteCreateDto"></param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(ContaCorrenteCreateDTO contaCorrenteCreateDto)
        {

            if (ModelState.IsValid)
            {
                var contaCorrente = await _contaCorrenteService.Add(contaCorrenteCreateDto);
                return CreatedAtAction(nameof(QuestaoCincoController.GetById), new { id = contaCorrente.ContaId }, contaCorrente);
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Obter saldo da conta
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
        public async Task<ActionResult> GetSaldoByContaId(string id)
        {
            var contaCorrente = await _contaCorrenteService.GetSaldoByContaId(id);

            if (contaCorrente == null)
                return NotFound("Conta nao cadastrada");

            return Ok(contaCorrente);
        }

        /// <summary>
        /// Realizar um lancamento
        /// </summary>
        /// <remarks>
        /// {"debitoCredito": "C","valor": 90,"contaId": "CONTA UM"}
        /// </remarks>
        /// <param name="lancamentoDTO">Dados do lancamento</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost("Lancamento")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Lancamento(LancamentoCreateDTO lancamentoDTO)
        {
            if (ModelState.IsValid)
            {
                var contaCorrente = await _contaCorrenteService.GetSaldoByContaId(lancamentoDTO.ContaId);

                if (contaCorrente == null)
                    return NotFound("Conta nao cadastrada");

                lancamentoDTO.SaldoAntes = contaCorrente.SaldoAtual;

                if (lancamentoDTO.DebitoCredito == "C")
                    lancamentoDTO.SaldoApos =(lancamentoDTO.Valor+contaCorrente.SaldoAtual);
                else
                    lancamentoDTO.SaldoApos = (contaCorrente.SaldoAtual - (lancamentoDTO.Valor+3.5M));

                await _lancamentoService.Add(lancamentoDTO);

                contaCorrente.SaldoAtual = lancamentoDTO.SaldoApos;

                await _contaCorrenteService.UpdateSaldoByContaId(contaCorrente);

                return CreatedAtAction(nameof(QuestaoCincoController.GetById), new { id = contaCorrente.ContaId }, contaCorrente);
            }

            return BadRequest();
        }

    }
}

