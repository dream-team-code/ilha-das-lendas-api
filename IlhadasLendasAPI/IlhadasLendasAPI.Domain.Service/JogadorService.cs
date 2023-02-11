using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories;
using IlhadasLendasAPI.Domain.Core.Interfaces.Services;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;
using IlhadasLendasAPI.Domain.Service.Base;

namespace IlhadasLendasAPI.Domain.Service
{
    public class JogadorService : ServiceBase<Jogador>, IJogadorService
    {
        private readonly IJogadorRepository jogadorRepository;

        public JogadorService(IJogadorRepository jogadorRepository) : base(jogadorRepository)
        {
            this.jogadorRepository = jogadorRepository;
        }

        public async Task<PagedList<Jogador>> GetPaginationAsync(ParametersJogador parametersJogador)
        {
            return await jogadorRepository.GetPaginationAsync(parametersJogador);
        }

        public bool ValidarId(Guid id)
        {
            return jogadorRepository.ValidarId(id);
        }
    }
}