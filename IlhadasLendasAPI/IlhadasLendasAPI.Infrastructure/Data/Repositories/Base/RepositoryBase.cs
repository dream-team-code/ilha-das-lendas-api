using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories.Base;
using IlhadasLendasAPI.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace IlhadasLendasAPI.Infrastructure.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly AppDbContext appDbContext;

        public RepositoryBase(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await appDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await appDbContext.Set<TEntity>()
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<TEntity> GetByIdTrackingAsync(Guid id)
        {
            return await appDbContext.Set<TEntity>()
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<TEntity> PostAsync(TEntity obj)
        {
            appDbContext.Set<TEntity>().Add(obj);
            await appDbContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity> PutAsync(TEntity obj)
        {
            var result = await GetByIdAsync(obj.Id);

            if (result is null)
                return null;

            appDbContext.Entry(obj).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity> PutStatusAsync(TEntity obj)
        {
            var result = await GetByIdAsync(obj.Id);

            if (result is null)
                return null;

            appDbContext.Entry(obj).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);

            if (obj is not null)
            {
                appDbContext.Remove(obj);
                await appDbContext.SaveChangesAsync();
            }

            return obj;
        }

        public virtual async Task<bool> ExisteNaBaseAsync(Guid id)
        {
            return await appDbContext.Set<TEntity>().AnyAsync(x => x.Id == id);
        }

        public virtual async Task SaveChangesAsync()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}