using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Domain.Core.Interfaces.Repositories
{
    public interface IJogadorRepository : IRepositoryBase<Jogador>
    {
        Task<PagedList<Jogador>> GetPaginationAsync(ParametersJogador parametersJogador);

        bool ValidarId(Guid id);
    }
}