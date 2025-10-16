using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1
{
    public class DeleteAvisoHandler : IRequestHandler<DeleteAvisoCommand, IOperationResult<Unit>>
    {
        private readonly IAvisoRepository _avisoRepository;

        public DeleteAvisoHandler(IAvisoRepository avisoRepository) => _avisoRepository = avisoRepository;

        public async Task<IOperationResult<Unit>> Handle(DeleteAvisoCommand request, CancellationToken cancellationToken)
        {
            var aviso = await _avisoRepository.GetByIdAsync(request.Id, cancellationToken);
            if (aviso == null)
                return OperationResult<Unit>.ReturnNoContent();

            if (!aviso.Ativo)
                return OperationResult<Unit>.ReturnOk(Unit.Value);

            aviso.Ativo = false;

            await _avisoRepository.AtualizarAviso(aviso, cancellationToken);

            return OperationResult<Unit>.ReturnOk(Unit.Value);
        }
    }
}
