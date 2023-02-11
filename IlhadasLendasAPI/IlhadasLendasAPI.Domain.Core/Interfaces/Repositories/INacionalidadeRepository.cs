using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Domain.Core.Interfaces.Repositories
{
    public interface INacionalidadeRepository : IRepositoryBase<Nacionalidade>
    {
        Task<PagedList<Nacionalidade>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}