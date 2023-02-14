using IlhadasLendasAPI.Domain.Core;
using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Enum;
using IlhadasLendasAPI.Domain.Pagination;
using IlhadasLendasAPI.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace IlhadasLendasAPI.Infrastructure.Data.Repositories
{
    public class JogadorRepository : RepositoryBase<Jogador>, IJogadorRepository
    {
        private readonly AppDbContext appDbContext;

        public JogadorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Jogador>> GetPaginationAsync(ParametersJogador parametersJogador)
        {
            IQueryable<Jogador> jogador = appDbContext.Jogadores.Include(x => x.Role).Include(x => x.Nacionalidade).AsNoTracking();

            if (parametersJogador.Id == null && parametersJogador.Status == 0)
                jogador = jogador.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersJogador.Status != 0)
                jogador = jogador.Where(x => x.Status == parametersJogador.Status.ToString());

            if (!string.IsNullOrEmpty(parametersJogador.PalavraChave))
                jogador = jogador.Where(programa => EF.Functions.Like(programa.Nome, $"%{parametersJogador.PalavraChave}%"));

            if (parametersJogador.Id != null)
                jogador = jogador.Where(x => parametersJogador.Id.Contains(x.Id));

            jogador = jogador.OrderBy(x => x.Role).ThenByDescending(x => x.Pontuacao);

            if (parametersJogador.DreamTeam)
            {
                IEnumerable<Jogador> groupByDreamTeam = jogador.GroupBy(x => x.RoleId, (key, g) => g.OrderByDescending(e => e.Pontuacao).First());
                jogador = jogador.Where(x => groupByDreamTeam.Contains(x));
            }

            return await Task.FromResult(PagedList<Jogador>.ToPagedList(jogador, parametersJogador.NumeroPagina, parametersJogador.ResultadosExibidos));
        }

        public override Task<Jogador> PostAsync(Jogador obj)
        {
            obj.CarregaCategoriaJogador();
            return base.PostAsync(obj);
        }

        public override Task<Jogador> PutAsync(Jogador obj)
        {
            obj.CarregaCategoriaJogador();
            return base.PutAsync(obj);
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.Jogadores.Any(x => x.Id == id);
        }
    }
}