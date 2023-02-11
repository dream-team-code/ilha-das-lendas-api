using IlhadasLendasAPI.Domain.Core.Interfaces.Services.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Domain.Core.Interfaces.Services
{
    public interface IJogadorService : IServiceBase<Jogador>
    {
        Task<PagedList<Jogador>> GetPaginationAsync(ParametersJogador parametersJogador);

        bool ValidarId(Guid id);
    }
}