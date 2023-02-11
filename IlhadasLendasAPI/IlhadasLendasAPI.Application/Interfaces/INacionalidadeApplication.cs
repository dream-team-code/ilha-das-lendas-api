using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Nacionalidade;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Interfaces.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Application.Interfaces
{
    public interface INacionalidadeApplication : IApplicationBase<Nacionalidade, ViewNacionalidadeDto, PostNacionalidadeDto, PutNacionalidadeDto, PutStatusDto>
    {
        Task<ViewPagedListDto<Nacionalidade, ViewNacionalidadeDto>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}