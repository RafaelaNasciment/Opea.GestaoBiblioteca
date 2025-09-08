using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.LivroService.CriarLivro;
using Opea.GestaoBiblioteca.Application.UseCases.LivroService.ListarLivros;
using Opea.GestaoBiblioteca.Application.UseCases.LivroService.ObterLivroPorId;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;

namespace Opea.GestaoBiblioteca.Api.Controllers
{
    [ApiController]
    [Route("v1/livro")]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LivroController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("v1")]
        [ProducesResponseType(typeof(Response<LivroResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Criar(
            [FromBody] CriarLivroRequest request,
            CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("v1/ObterPorId")]
        [ProducesResponseType(typeof(Response<LivroResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPorId(
            [FromQuery] ObterLivroPorIdRequest request,
            CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("v1/ListarLivros")]
        [ProducesResponseType(typeof(Response<ListarLivroResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarLivros(
            [FromQuery] ListarLivrosRequest request,
            CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}