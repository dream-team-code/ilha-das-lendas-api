using IlhadasLendasAPI.Domain.Core.Interfaces.Repositories;
using IlhadasLendasAPI.Domain.Core.Interfaces.Services;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;
using IlhadasLendasAPI.Domain.Service.Base;

namespace IlhadasLendasAPI.Domain.Service
{
    public class RoleService : ServiceBase<Role>, IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository) : base(roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public async Task<PagedList<Role>> GetPaginationAsync(ParametersBase parametersBase)
        {
            return await roleRepository.GetPaginationAsync(parametersBase);
        }

        public bool ValidarId(Guid id)
        {
            return roleRepository.ValidarId(id);
        }
    }
}