using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Domain.Core.Interfaces.Repositories
{
    public interface ITimeRepository : IRepositoryBase<Time>
    {
        Task<PagedList<Time>> GetPaginationAsync(ParametersTime parametersTime);

        bool ValidarId(Guid id);
    }
}