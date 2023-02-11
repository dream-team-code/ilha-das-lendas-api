using AutoMapper;
using IlhadasLendasAPI.Application.Applications.Base;
using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Jogador;
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
    public class JogadorApplication : ApplicationBase<Jogador, ViewJogadorDto, PostJogadorDto, PutJogadorDto, PutStatusDto>, IJogadorApplication
    {
        private readonly IJogadorService jogadorService;

        public JogadorApplication(IJogadorService jogadorService,
                                INotificador notificador,
                                IMapper mapper) : base(jogadorService, notificador, mapper)
        {
            this.jogadorService = jogadorService;
        }

        public async Task<ViewPagedListDto<Jogador, ViewJogadorDto>> GetPaginationAsync(ParametersJogador parametersJogador)
        {
            PagedList<Jogador> pagedList = await jogadorService.GetPaginationAsync(parametersJogador);
            return new ViewPagedListDto<Jogador, ViewJogadorDto>(pagedList, mapper.Map<List<ViewJogadorDto>>(pagedList));
        }

        public async Task<ViewJogadorDto> PostAsync(PostJogadorDto postJogadorDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao)
        {
            Jogador Jogador = mapper.Map<Jogador>(postJogadorDto);

            Jogador.PolulateInformations(await PathCreator.CreateIpPath(caminhoFisico),
                                          await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                          await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo), extensao);

            UploadB64Methods<Jogador> uploadClass = new();
            await uploadClass.UploadImagem(Jogador.CaminhoFisico, base64string);

            return mapper.Map<ViewJogadorDto>(await jogadorService.PostAsync(Jogador));
        }

        public async Task<ViewJogadorDto> PutAsync(PutJogadorDto putJogadorDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao)
        {
            Jogador Jogador = mapper.Map<Jogador>(putJogadorDto);
            Jogador JogadorConsultado = await jogadorService.GetByIdAsync(putJogadorDto.Id);

            if (JogadorConsultado is null)
                return null;

            if (!string.IsNullOrWhiteSpace(base64string))
            {
                UploadB64Methods<Jogador> uploadClass = new();
                await uploadClass.DeleteImage(JogadorConsultado);

                Jogador.PolulateInformations(await PathCreator.CreateIpPath(caminhoFisico),
                                              await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                              await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo), extensao);

                await uploadClass.UploadImagem(Jogador.CaminhoFisico, base64string);
            }
            else
            {
                Jogador.PutInformations(JogadorConsultado);
            }

            return mapper.Map<ViewJogadorDto>(await jogadorService.PutAsync(Jogador));
        }

        public bool ValidarId(Guid id)
        {
            return jogadorService.ValidarId(id);
        }
    }
}