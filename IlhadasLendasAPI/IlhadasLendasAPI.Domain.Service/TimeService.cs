using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories;
using IlhadasLendasAPI.Domain.Core.Interfaces.Services;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;
using IlhadasLendasAPI.Domain.Service.Base;

namespace IlhadasLendasAPI.Domain.Service
{
    public class TimeService : ServiceBase<Time>, ITimeService
    {
        private readonly ITimeRepository timeRepository;

        public TimeService(ITimeRepository timeRepository) : base(timeRepository)
        {
            this.timeRepository = timeRepository;
        }

        public async Task<PagedList<Time>> GetPaginationAsync(ParametersTime parametersTime)
        {
            return await timeRepository.GetPaginationAsync(parametersTime);
        }

        public bool ValidarId(Guid id)
        {
            return timeRepository.ValidarId(id);
        }
    }
}