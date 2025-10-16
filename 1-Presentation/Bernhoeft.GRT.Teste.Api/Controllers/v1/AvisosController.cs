using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;

namespace Bernhoeft.GRT.Teste.Api.Controllers.v1
{
    /// <response code="401">Não Autenticado.</response>
    /// <response code="403">Não Autorizado.</response>
    /// <response code="500">Erro Interno no Servidor.</response>
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = null)]
    public class AvisosController : RestApiController
    {

        /// <summary>
        /// Retorna Todos os Avisos Cadastrados para Tela de Edição.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Lista com Todos os Avisos.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Sem Avisos.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDocumentationRestResult<IEnumerable<GetAvisosResponse>>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<object> GetAvisos(CancellationToken cancellationToken)
            => await Mediator.Send(new GetAvisosRequest(), cancellationToken);

        /// <summary>
        /// Retorna um aviso de acordo com o Id.
        /// </summary>
        /// <param name="id">Id do aviso.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Lista com Todos os Avisos.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="400">Id inválido.</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDocumentationRestResult<GetAvisosResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<object> GetAvisoById(int id, CancellationToken cancellationToken)
            => await Mediator.Send(new GetAvisoByIdRequest(id), cancellationToken);

        /// <summary>
        /// Cria um novo aviso.
        /// </summary>
        /// <param name="aviso">Dados do aviso.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="204">Aviso criado.</response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IDocumentationRestResult<GetAvisosResponse>))]
        public async Task<object> CreateAviso([FromBody] CreateAvisoCommand aviso, CancellationToken cancellationToken)
            => await Mediator.Send(aviso, cancellationToken);

        /// <summary>
        /// Atualiza um aviso.
        /// </summary>
        /// <param name="id">Id do aviso.</param>
        /// <param name="command">Dados do Aviso</param>
        /// <returns></returns>
        /// <response code="201">Aviso criado.</response>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDocumentationRestResult<GetAvisosResponse>))]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAvisoCommand command)
        {
            if (id != command.Id)
                return BadRequest("Dados inválidos.");

            var result = await Mediator.Send(command);

            if(!result.IsSuccessTypeResult)
                return NoContent();

            return Ok(result.Data);
        }

        /// <summary>
        /// Apaga um aviso.
        /// </summary>
        /// <param name="id">Id do aviso.</param>
        /// <returns></returns>
        /// <response code="204">Aviso criado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteAvisoCommand(id));
            if (!result.IsSuccessTypeResult)
                return NoContent();
            return Ok("Aviso apagado com sucesso.");
        }
    }
}