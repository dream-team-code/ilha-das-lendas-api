using AutoMapper;
using IlhadasLendasAPI.Application.Applications.Base;
using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Nacionalidade;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Interfaces;
using IlhadasLendasAPI.Domain.Core.Interfaces.Services;
using IlhadasLendasAPI.Domain.Core.Notifier;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Application.Applications
{
    public class NacionalidadeApplication : ApplicationBase<Nacionalidade, ViewNacionalidadeDto, PostNacionalidadeDto, PutNacionalidadeDto, PutStatusDto>, INacionalidadeApplication
    {
        private readonly INacionalidadeService NacionalidadeService;

        public NacionalidadeApplication(INacionalidadeService NacionalidadeService,
                                INotificador notificador,
                                IMapper mapper) : base(NacionalidadeService, notificador, mapper)
        {
            this.NacionalidadeService = NacionalidadeService;
        }

        public async Task<ViewPagedListDto<Nacionalidade, ViewNacionalidadeDto>> GetPaginationAsync(ParametersBase parametersBase)
        {
            PagedList<Nacionalidade> pagedList = await NacionalidadeService.GetPaginationAsync(parametersBase);
            return new ViewPagedListDto<Nacionalidade, ViewNacionalidadeDto>(pagedList, mapper.Map<List<ViewNacionalidadeDto>>(pagedList));
        }

        public bool ValidarId(Guid id)
        {
            return NacionalidadeService.ValidarId(id);
        }
    }
}