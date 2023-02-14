using IlhadasLendasAPI.API.Controllers;
using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Dtos.Role;
using IlhadasLendasAPI.Application.Interfaces;
using IlhadasLendasAPI.Domain.Core;
using IlhadasLendasAPI.Domain.Core.Notifier;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Enum;
using IlhadasLendasAPI.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace IlhadasLendasAPI.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/Roles")]
    [ApiController]
    public class RoleController : MainController
    {
        private readonly IRoleApplication roleApplication;

        public RoleController(IRoleApplication roleApplication,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.roleApplication = roleApplication;
        }

        /// <summary>
        /// Retorna todas as Roles com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<Role, ViewRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDto<Role, ViewRoleDto> result = await roleApplication.GetPaginationAsync(parameters);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhum Role foi encontrado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "Roles encontrados.");
        }

        /// <summary>
        /// Insere uma nova Role.
        /// </summary>
        /// <param name="postRoleDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostRoleDto postRoleDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewRoleDto inserido = await roleApplication.PostAsync(postRoleDto);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir o Role.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "Role criado com sucesso!");
        }

        /// <summary>
        /// Altera uma Role.
        /// </summary>
        /// <param name="putRoleDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] PutRoleDto putRoleDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewRoleDto atualizado = await roleApplication.PutAsync(putRoleDto);

            if (atualizado is null)
            {
                NotificarErro("Nenhum Role foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(atualizado, "Role atualizado com sucesso!");
        }

        /// <summary>
        /// Exclui uma Role.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um Role o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewRoleDto removido = await roleApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhuma Role foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "Role excluído com sucesso!");
        }
    }
}