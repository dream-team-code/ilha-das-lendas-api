using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Enum;
using IlhadasLendasAPI.Domain.Pagination;
using IlhadasLendasAPI.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace IlhadasLendasAPI.Infrastructure.Data.Repositories
{
    public class TimeRepository : RepositoryBase<Time>, ITimeRepository
    {
        private readonly AppDbContext appDbContext;

        public TimeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Time>> GetPaginationAsync(ParametersTime parametersTime)
        {
            IQueryable<Time> times = appDbContext.Times
                                                .Include(x => x.Jogadores)
                                                .ThenInclude(x => x.Role)
                                                .Include(x => x.Jogadores)
                                                .ThenInclude(x => x.Nacionalidade)
                                                .AsNoTracking();

            if (parametersTime.Id == null && parametersTime.Status == 0)
                times = times.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersTime.Status != 0)
                times = times.Where(x => x.Status == parametersTime.Status.ToString());

            if (parametersTime.Id != null)
                times = times.Where(x => parametersTime.Id.Contains(x.Id));

            times = times.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<Time>.ToPagedList(times, parametersTime.NumeroPagina, parametersTime.ResultadosExibidos));
        }

        public override async Task<Time> PostAsync(Time time)
        {
            return await base.PostAsync(await InserirTimeAsync(time));
        }

        private async Task<Time> InserirTimeAsync(Time time)
        {
            await InsertJogadoresAsync(time);
            return time;
        }

        private async Task InsertJogadoresAsync(Time time)
        {
            List<Jogador> jogadoresConsultadas = new List<Jogador>();

            foreach (Jogador cadeira in time.Jogadores)
            {
                Jogador jogadorConsultada = await appDbContext.Jogadores.FindAsync(cadeira.Id);
                jogadoresConsultadas.Add(jogadorConsultada);
            }

            time.AlterarJogadores(jogadoresConsultadas);
        }

        public override async Task<Time> PutAsync(Time time)
        {
            return await base.PutAsync(await AtualizarTimeAsync(time));
        }

        private async Task<Time> AtualizarTimeAsync(Time time)
        {
            Time timeConsultado = await appDbContext.Times
                         .Include(x => x.Jogadores)
                         .FirstOrDefaultAsync(x => x.Id == time.Id);

            if (timeConsultado is null)
                return null;

            appDbContext.Entry(timeConsultado).CurrentValues.SetValues(time);

            await AtualizarJogadoresAsync(time, timeConsultado);

            return timeConsultado;
        }

        private async Task AtualizarJogadoresAsync(Time time, Time timeConsultado)
        {
            timeConsultado.Jogadores.Clear();
            foreach (Jogador jogador in time.Jogadores)
            {
                Jogador jogadorConsultado = await appDbContext.Jogadores.FindAsync(jogador.Id);
                timeConsultado.Jogadores.Add(jogadorConsultado);
            }
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.Times.Any(x => x.Id == id);
        }
    }
}