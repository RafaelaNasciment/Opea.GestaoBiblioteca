using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opea.GestaoBiblioteca.Application.Services.EmprestimoService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.EmprestimoService.DevolverEmprestimo;
using Opea.GestaoBiblioteca.Application.UseCases.EmprestimoService.SolicitarEmprestimo;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;

namespace Opea.GestaoBiblioteca.Api.Controllers
{
    [ApiController]
    [Route("v1/emprestimo")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmprestimoController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("v1/SolicitarEmprestimo")]
        [ProducesResponseType(typeof(Response<EmprestimoResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SolicitarEmprestimo(
            [FromBody] SolicitarEmprestimoRequest request,
            CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpPost("v1/DevolverEmprestimo")]
        [ProducesResponseType(typeof(Response<EmprestimoResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DevolverEmprestimo(
            [FromBody] DevolverEmprestimoRequest request,
            CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}
