using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Enum;
using IlhadasLendasAPI.Domain.Pagination;
using IlhadasLendasAPI.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace IlhadasLendasAPI.Infrastructure.Data.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        private readonly AppDbContext appDbContext;

        public RoleRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Role>> GetPaginationAsync(ParametersBase parametersBase)
        {
            IQueryable<Role> role = appDbContext.Roles.AsNoTracking();

            if (parametersBase.Id == null && parametersBase.Status == 0)
                role = role.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersBase.Status != 0)
                role = role.Where(x => x.Status == parametersBase.Status.ToString());

            if (parametersBase.Id != null)
                role = role.Where(x => parametersBase.Id.Contains(x.Id));

            role = role.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<Role>.ToPagedList(role, parametersBase.NumeroPagina, parametersBase.ResultadosExibidos));
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.Roles.Any(x => x.Id == id);
        }
    }
}