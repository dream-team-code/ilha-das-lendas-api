using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories.Base;
using IlhadasLendasAPI.Domain.Core.Interfaces.Services.Base;
using IlhadasLendasAPI.Domain.Core.Notifier;
using IlhadasLendasAPI.Domain.Entities.Base;

namespace IlhadasLendasAPI.Domain.Service.Base
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> repositoryBase;
        private readonly INotificador notificador;

        protected ServiceBase(IRepositoryBase<TEntity> repositoryBase, INotificador notificador)
        {
            this.notificador = notificador;
            this.repositoryBase = repositoryBase;
        }

        protected void Notificar(string mensagem)
        {
            notificador.Handle(new Notificacao(mensagem));
        }

        protected ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repositoryBase.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await repositoryBase.GetByIdAsync(id);
        }

        public virtual async Task<TEntity> GetByIdTrackingAsync(Guid id)
        {
            return await repositoryBase.GetByIdTrackingAsync(id);
        }

        public virtual async Task<TEntity> PostAsync(TEntity obj)
        {
            return await repositoryBase.PostAsync(obj);
        }

        public virtual async Task<TEntity> PutAsync(TEntity obj)
        {
            return await repositoryBase.PutAsync(obj);
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id)
        {
            return await repositoryBase.DeleteAsync(id);
        }

        public async Task<TEntity> PutStatusAsync(TEntity obj)
        {
            return await repositoryBase.PutStatusAsync(obj);
        }

        public virtual async Task<bool> ExisteNaBaseAsync(Guid id)
        {
            return await repositoryBase.ExisteNaBaseAsync(id);
        }

        public virtual async Task SaveChangesAsync()
        {
            await repositoryBase.SaveChangesAsync();
        }
    }
}