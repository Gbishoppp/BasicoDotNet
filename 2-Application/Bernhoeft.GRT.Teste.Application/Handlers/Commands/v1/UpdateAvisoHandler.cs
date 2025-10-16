using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1
{
    public class UpdateAvisoHandler : IRequestHandler<UpdateAvisoCommand, IOperationResult<AvisosResponse>>
    {
        private readonly IAvisoRepository _avisoRepository;

        public UpdateAvisoHandler(IAvisoRepository avisoRepository)
        {
            _avisoRepository = avisoRepository;
        }

        public async Task<IOperationResult<AvisosResponse>> Handle(UpdateAvisoCommand request, CancellationToken cancellationToken)
        {
            var aviso = await _avisoRepository.GetByIdAsync(request.Id, cancellationToken);

            if (aviso == null)
                return OperationResult<AvisosResponse>.ReturnNoContent().AddMessage("Aviso não encontrado");

            aviso.Mensagem = request.Mensagem;
            aviso.DataAlteracao = DateTime.Now;

            await _avisoRepository.AtualizarAviso(aviso, cancellationToken);

            return OperationResult<AvisosResponse>.ReturnOk(aviso);
        }
    }
}
