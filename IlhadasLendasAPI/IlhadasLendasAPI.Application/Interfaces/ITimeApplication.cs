using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Dtos.Time;
using IlhadasLendasAPI.Application.Interfaces.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Application.Interfaces
{
    public interface ITimeApplication : IApplicationBase<Time, ViewTimeDto, PostTimeDto, PutTimeDto, PutStatusDto>
    {
        Task<ViewPagedListDto<Time, ViewTimeDto>> GetPaginationAsync(ParametersTime parametersTime);

        Task<ViewTimeDto> PostAsync(PostTimeDto postTimeDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao);

        Task<ViewTimeDto> PutAsync(PutTimeDto putTimeDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao);

        bool ValidarId(Guid id);
    }
}