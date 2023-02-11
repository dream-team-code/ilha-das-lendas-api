using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Jogador;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Interfaces.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Application.Interfaces
{
    public interface IJogadorApplication : IApplicationBase<Jogador, ViewJogadorDto, PostJogadorDto, PutJogadorDto, PutStatusDto>
    {
        Task<ViewPagedListDto<Jogador, ViewJogadorDto>> GetPaginationAsync(ParametersJogador parametersJogador);

        Task<ViewJogadorDto> PostAsync(PostJogadorDto postJogadorDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao);

        Task<ViewJogadorDto> PutAsync(PutJogadorDto putJogadorDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo, string base64string, string extensao);

        bool ValidarId(Guid id);
    }
}