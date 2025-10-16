using Bernhoeft.GRT.Core.Attributes;
using Bernhoeft.GRT.Core.EntityFramework.Infra;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Teste.Domain.Entities;
using Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bernhoeft.GRT.Teste.Infra.Persistence.InMemory.Repositories
{
    [InjectService(Interface: typeof(IAvisoRepository))]
    public class AvisoRepository : Repository<AvisoEntity>, IAvisoRepository
    {
        public AvisoRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task AtualizarAviso(AvisoEntity aviso, CancellationToken cancellationToken)
        {
            var result = Update(aviso);
            return Task.CompletedTask;

        }

        public Task<AvisoEntity> CriarAviso(string Titulo, string Mensagem, bool Ativo, CancellationToken cancellationToken)
        {
            var aviso = new AvisoEntity
            {
                Ativo = Ativo,
                Titulo = Titulo,
                Mensagem = Mensagem,
                DataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now
            };
            var result = AddAsync(aviso, cancellationToken);
            return result;
        }

        public AvisoEntity ObterByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            var result = GetById(Id);
            return result;
        }

        public Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
        {
            var query = tracking is TrackingBehavior.NoTracking ? Set.AsNoTrackingWithIdentityResolution() : Set;
            return query.Where(x => x.Ativo == true).ToListAsync();
        }
    }
}