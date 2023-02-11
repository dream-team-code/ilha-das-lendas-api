using IlhadasLendasAPI.Domain.Core.Interfaces.Services.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Domain.Core.Interfaces.Services
{
    public interface INacionalidadeService : IServiceBase<Nacionalidade>

    {
        Task<PagedList<Nacionalidade>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}