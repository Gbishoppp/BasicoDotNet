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
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1
{
    public class CreateAvisoHandler : IRequestHandler<CreateAvisoCommand, IOperationResult<GetAvisosResponse>>
    {
        private readonly IAvisoRepository _avisoRepository;
        public CreateAvisoHandler(IAvisoRepository avisoRepository)
        {
            _avisoRepository = avisoRepository;
        }

        public Task<IOperationResult<GetAvisosResponse>> Handle(CreateAvisoCommand request, CancellationToken cancellationToken)
        {
            var command = _avisoRepository.CriarAviso(request.Titulo, request.Titulo, request.Ativo, cancellationToken);

            //if (!command.IsCompletedSuccessfully)
                //return Task.FromResult(OperationResult<GetAvisosResponse>.ReturnInternalServerError());

            return Task.FromResult(OperationResult<GetAvisosResponse>.ReturnCreated());
        }
    }
}
