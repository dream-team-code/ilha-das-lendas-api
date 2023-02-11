using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories;
using IlhadasLendasAPI.Domain.Core.Interfaces.Services;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;
using IlhadasLendasAPI.Domain.Service.Base;

namespace IlhadasLendasAPI.Domain.Service
{
    public class NacionalidadeService : ServiceBase<Nacionalidade>, INacionalidadeService
    {
        private readonly INacionalidadeRepository nacionalidadeRepository;

        public NacionalidadeService(INacionalidadeRepository nacionalidadeRepository) : base(nacionalidadeRepository)
        {
            this.nacionalidadeRepository = nacionalidadeRepository;
        }

        public async Task<PagedList<Nacionalidade>> GetPaginationAsync(ParametersBase parametersBase)
        {
            return await nacionalidadeRepository.GetPaginationAsync(parametersBase);
        }

        public bool ValidarId(Guid id)
        {
            return nacionalidadeRepository.ValidarId(id);
        }
    }
}