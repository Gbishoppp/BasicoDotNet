using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public record CreateAvisoCommand(string Titulo, string Mensagem, bool Ativo = true) : IRequest<IOperationResult<GetAvisosResponse>>;
   
}
