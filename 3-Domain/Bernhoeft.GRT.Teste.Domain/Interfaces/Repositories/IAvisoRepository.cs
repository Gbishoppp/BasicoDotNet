using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Teste.Domain.Entities;

namespace Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories
{
    public interface IAvisoRepository : IRepository<AvisoEntity>
    {
        Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        AvisoEntity ObterByIdAsync(int Id, CancellationToken cancellationToken = default);
        Task<AvisoEntity> CriarAviso(string Titulo, string Mensagem, bool Ativo, CancellationToken cancellationToken);
        Task AtualizarAviso(AvisoEntity aviso, CancellationToken cancellationToken);
    }
}