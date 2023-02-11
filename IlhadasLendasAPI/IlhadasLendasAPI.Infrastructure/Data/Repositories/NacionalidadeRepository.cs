using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Enum;
using IlhadasLendasAPI.Domain.Pagination;
using IlhadasLendasAPI.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace IlhadasLendasAPI.Infrastructure.Data.Repositories
{
    public class NacionalidadeRepository : RepositoryBase<Nacionalidade>, INacionalidadeRepository
    {
        private readonly AppDbContext appDbContext;

        public NacionalidadeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Nacionalidade>> GetPaginationAsync(ParametersBase parametersBase)
        {
            IQueryable<Nacionalidade> nacionalidade = appDbContext.Nacionalidades.AsNoTracking();

            if (parametersBase.Id == null && parametersBase.Status == 0)
                nacionalidade = nacionalidade.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersBase.Status != 0)
                nacionalidade = nacionalidade.Where(x => x.Status == parametersBase.Status.ToString());

            if (parametersBase.Id != null)
                nacionalidade = nacionalidade.Where(x => parametersBase.Id.Contains(x.Id));

            nacionalidade = nacionalidade.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<Nacionalidade>.ToPagedList(nacionalidade, parametersBase.NumeroPagina, parametersBase.ResultadosExibidos));
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.Nacionalidades.Any(x => x.Id == id);
        }
    }
}