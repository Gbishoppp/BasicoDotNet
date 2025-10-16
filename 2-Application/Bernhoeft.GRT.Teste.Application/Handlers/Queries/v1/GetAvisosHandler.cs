using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Extensions;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class GetAvisosHandler : IRequestHandler<GetAvisosRequest, IOperationResult<IEnumerable<AvisosResponse>>>
    {
        private readonly IServiceProvider _serviceProvider;

        private IContext _context => _serviceProvider.GetRequiredService<IContext>();
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

        public GetAvisosHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<IEnumerable<AvisosResponse>>> Handle(GetAvisosRequest request, CancellationToken cancellationToken)
        {
            var result = await _avisoRepository.ObterTodosAvisosAsync(TrackingBehavior.NoTracking);
            if (!result.HaveAny())
                return OperationResult<IEnumerable<AvisosResponse>>.ReturnNoContent();

            return OperationResult<IEnumerable<AvisosResponse>>.ReturnOk(result.Select(x => (AvisosResponse)x));
        }
    }
}