using IlhadasLendasAPI.API.Controllers;
using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Domain.Core.Notifier;
using IlhadasLendasAPI.Domain.Core;
using IlhadasLendasAPI.Domain.Enum;
using IlhadasLendasAPI.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;
using IlhadasLendasAPI.Application.Interfaces;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Application.Dtos.Nacionalidade;

namespace IlhadasLendasAPI.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/Nacionalidades")]
    [ApiController]
    public class NacionalidadeController : MainController
    {
        private readonly INacionalidadeApplication nacionaldiadeApplication;

        public NacionalidadeController(INacionalidadeApplication nacionaldiadeApplication,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.nacionaldiadeApplication = nacionaldiadeApplication;
        }

        /// <summary>
        /// Retorna todas as Nacionalidades com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<Nacionalidade, ViewNacionalidadeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDto<Nacionalidade, ViewNacionalidadeDto> result = await nacionaldiadeApplication.GetPaginationAsync(parameters);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhum Nacionalidade foi encontrado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "Nacionalidades encontrados.");
        }

        /// <summary>
        /// Insere uma nova Nacionalidade.
        /// </summary>
        /// <param name="postNacionalidadeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewNacionalidadeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostNacionalidadeDto postNacionalidadeDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewNacionalidadeDto inserido = await nacionaldiadeApplication.PostAsync(postNacionalidadeDto);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir o Nacionalidade.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "Nacionalidade criado com sucesso!");
        }

        /// <summary>
        /// Altera uma Nacionalidade.
        /// </summary>
        /// <param name="putNacionalidadeDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewNacionalidadeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] PutNacionalidadeDto putNacionalidadeDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewNacionalidadeDto atualizado = await nacionaldiadeApplication.PutAsync(putNacionalidadeDto);

            if (atualizado is null)
            {
                NotificarErro("Nenhum Nacionalidade foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(atualizado, "Nacionalidade atualizado com sucesso!");
        }

        /// <summary>
        /// Exclui uma Nacionalidade.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um Nacionalidade o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewNacionalidadeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewNacionalidadeDto removido = await nacionaldiadeApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhuma Nacionalidade foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "Nacionalidade excluído com sucesso!");
        }
    }
}