using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Dtos.Role;
using IlhadasLendasAPI.Application.Interfaces.Base;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Pagination;

namespace IlhadasLendasAPI.Application.Interfaces
{
    public interface IRoleApplication : IApplicationBase<Role, ViewRoleDto, PostRoleDto, PutRoleDto, PutStatusDto>
    {
        Task<ViewPagedListDto<Role, ViewRoleDto>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}