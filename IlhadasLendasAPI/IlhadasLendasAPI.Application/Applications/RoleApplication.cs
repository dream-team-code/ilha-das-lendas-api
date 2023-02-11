using AutoMapper;
using IlhadasLendasAPI.Application.Applications.Base;
using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Dtos.Role;
using IlhadasLendasAPI.Application.Interfaces;
using IlhadasLendasAPI.Domain.Core.Interfaces.Services;
using IlhadasLendasAPI.Domain.Core.Notifier;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Application.Applications
{
    public class RoleApplication : ApplicationBase<Role, ViewRoleDto, PostRoleDto, PutRoleDto, PutStatusDto>, IRoleApplication
    {
        private readonly IRoleService RoleService;

        public RoleApplication(IRoleService RoleService,
                                INotificador notificador,
                                IMapper mapper) : base(RoleService, notificador, mapper)
        {
            this.RoleService = RoleService;
        }

        public async Task<ViewPagedListDto<Role, ViewRoleDto>> GetPaginationAsync(ParametersBase parametersBase)
        {
            PagedList<Role> pagedList = await RoleService.GetPaginationAsync(parametersBase);
            return new ViewPagedListDto<Role, ViewRoleDto>(pagedList, mapper.Map<List<ViewRoleDto>>(pagedList));
        }

        public bool ValidarId(Guid id)
        {
            return RoleService.ValidarId(id);
        }
    }
}