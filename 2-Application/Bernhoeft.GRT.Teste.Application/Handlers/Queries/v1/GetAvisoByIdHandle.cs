using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class GetAvisoByIdHandle : IRequestHandler<GetAvisoByIdRequest, IOperationResult<AvisosResponse>>
    {
        private readonly IAvisoRepository _avisoRepository;
        public GetAvisoByIdHandle(IAvisoRepository avisoRepository)
        {
            _avisoRepository = avisoRepository;
        }
        public Task<IOperationResult<AvisosResponse>> Handle(GetAvisoByIdRequest request, CancellationToken cancellationToken)
        {
            var result = _avisoRepository.ObterByIdAsync(request.Id, cancellationToken);
            if (result == null)
                return Task.FromResult(OperationResult<AvisosResponse>.ReturnNotFound().AddMessage("Aviso não encontrado."));

            return Task.FromResult(OperationResult<AvisosResponse>.ReturnOk(result));
        }
    }
}
