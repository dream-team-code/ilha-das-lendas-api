using IlhadasLendasAPI.Domain.Core.Interfaces.Services.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Domain.Core.Interfaces.Services
{
    public interface IRoleService : IServiceBase<Role>
    {
        Task<PagedList<Role>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}