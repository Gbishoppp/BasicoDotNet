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
    public record UpdateAvisoCommand(int Id, string Titulo, string Mensagem, bool Ativo ) : IRequest<IOperationResult<AvisosResponse>>;
}  
