using IlhadasLendasAPI.Domain.Core.Interfaces.Services.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Domain.Core.Interfaces.Services
{
    public interface ITimeService : IServiceBase<Time>
    {
        Task<PagedList<Time>> GetPaginationAsync(ParametersTime parametersTime);

        bool ValidarId(Guid id);
    }
}