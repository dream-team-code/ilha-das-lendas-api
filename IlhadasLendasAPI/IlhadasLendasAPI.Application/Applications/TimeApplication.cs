using AutoMapper;
using IlhadasLendasAPI.Application.Applications.Base;
using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Time;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Interfaces;
using IlhadasLendasAPI.Application.Utilities.Image;
using IlhadasLendasAPI.Application.Utilities.Paths;
using IlhadasLendasAPI.Domain.Core.Interfaces.Services;
using IlhadasLendasAPI.Domain.Core.Notifier;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Application.Applications
{
    public class TimeApplication : ApplicationBase<Time, ViewTimeDto, PostTimeDto, PutTimeDto, PutStatusDto>, ITimeApplication
    {
        private readonly ITimeService TimeService;

        public TimeApplication(ITimeService TimeService,
                                INotificador notificador,
                                IMapper mapper) : base(TimeService, notificador, mapper)
        {
            this.TimeService = TimeService;
        }

        public async Task<ViewPagedListDto<Time, ViewTimeDto>> GetPaginationAsync(ParametersTime parametersTime)
        {
            PagedList<Time> pagedList = await TimeService.GetPaginationAsync(parametersTime);
            ViewPagedListDto<Time, ViewTimeDto> viewTimeDtos = new ViewPagedListDto<Time, ViewTimeDto>(pagedList, mapper.Map<List<ViewTimeDto>>(pagedList));

            foreach (ViewTimeDto time in viewTimeDtos.Pagina)
            {
                time.CarregaMedia();
            }

            return viewTimeDtos;
        }

        public async Task<ViewTimeDto> PostAsync(PostTimeDto postTimeDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao)
        {
            Time Time = mapper.Map<Time>(postTimeDto);

            Time.PolulateInformations(await PathCreator.CreateIpPath(caminhoFisico),
                                          await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                          await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo), extensao);

            UploadB64Methods<Time> uploadClass = new();
            await uploadClass.UploadImagem(Time.CaminhoFisico, base64string);

            return mapper.Map<ViewTimeDto>(await TimeService.PostAsync(Time));
        }

        public async Task<ViewTimeDto> PutAsync(PutTimeDto putTimeDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao)
        {
            Time Time = mapper.Map<Time>(putTimeDto);
            Time TimeConsultado = await TimeService.GetByIdAsync(putTimeDto.Id);

            if (TimeConsultado is null)
                return null;

            if (!string.IsNullOrWhiteSpace(base64string))
            {
                UploadB64Methods<Time> uploadClass = new();
                await uploadClass.DeleteImage(TimeConsultado);

                Time.PolulateInformations(await PathCreator.CreateIpPath(caminhoFisico),
                                              await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                              await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo), extensao);

                await uploadClass.UploadImagem(Time.CaminhoFisico, base64string);
            }
            else
            {
                Time.PutInformations(TimeConsultado);
            }

            return mapper.Map<ViewTimeDto>(await TimeService.PutAsync(Time));
        }

        public bool ValidarId(Guid id)
        {
            return TimeService.ValidarId(id);
        }
    }
}