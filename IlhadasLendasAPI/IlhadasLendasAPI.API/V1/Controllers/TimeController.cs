using IlhadasLendasAPI.API.Controllers;
using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Time;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Interfaces;
using IlhadasLendasAPI.Application.Utilities.Image;
using IlhadasLendasAPI.Application.Utilities.Paths;
using IlhadasLendasAPI.Domain.Core.Notifier;
using IlhadasLendasAPI.Domain.Core;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Enum;
using IlhadasLendasAPI.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace IlhadasLendasAPI.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/Times")]
    [ApiController]
    public class TimeController : MainController
    {
        private readonly ITimeApplication timeApplication;
        private readonly Ambiente Ambiente;

        public TimeController(ITimeApplication timeApplication,
                                 IWebHostEnvironment webHostEnvironment,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.timeApplication = timeApplication;
            Ambiente = webHostEnvironment.IsProduction() ? Ambiente.Producao : webHostEnvironment.IsStaging() ? Ambiente.Homologacao : Ambiente.Desenvolvimento;
        }

        /// <summary>
        /// Retorna todos os Times com filtro e paginação de dados.
        /// </summary>
        /// <param name="parametersTime"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<Time, ViewTimeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersTime parametersTime)
        {
            ViewPagedListDto<Time, ViewTimeDto> result = await timeApplication.GetPaginationAsync(parametersTime);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhum Time foi encontrado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "Times encontrados.");
        }

        /// <summary>
        /// Insere um Time.
        /// </summary>
        /// <param name="postTimeDto"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewTimeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostTimeDto postTimeDto, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (!await PathSystem.ValidateURLs(diretorio.ToString(), Ambiente))
            {
                NotificarErro("Diretório não encontrado.");
                return CustomResponse(ModelState);
            }

            Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorio.ToString(), Ambiente);

            string extensao = ExtensionSystem.GetExtensaoB64(postTimeDto.ImagemBase64);
            string base64String = ExtensionSystem.GetB64String(postTimeDto.ImagemBase64);

            if (extensao is null || base64String is null)
            {
                NotificarErro("Extensão não suportada ou texto não se encontra em Base64.");
                return CustomResponse(ModelState);
            }

            ViewTimeDto inserido = await timeApplication.PostAsync(postTimeDto, Urls["IP"], Urls["DNS"], Urls["SPLIT"], base64String, extensao);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir o Time.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "Time criado com sucesso!");
        }

        /// <summary>
        /// Altera um Time.
        /// </summary>
        /// <param name="putTimeDto"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewTimeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] PutTimeDto putTimeDto, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (!string.IsNullOrWhiteSpace(putTimeDto.ImagemBase64))
            {
                if (!await PathSystem.ValidateURLs(diretorio.ToString(), Ambiente))
                {
                    NotificarErro("Diretório não encontrado.");
                    return CustomResponse(ModelState);
                }

                Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorio.ToString(), Ambiente);

                string extensao = ExtensionSystem.GetExtensaoB64(putTimeDto.ImagemBase64);
                string base64String = ExtensionSystem.GetB64String(putTimeDto.ImagemBase64);

                if (extensao is null || base64String is null)
                {
                    NotificarErro("Extensão não suportada ou texto não se encontra em base64.");
                    return CustomResponse(ModelState);
                }

                ViewTimeDto atualizado = await timeApplication.PutAsync(putTimeDto, Urls["IP"], Urls["DNS"], Urls["SPLIT"], base64String, extensao);

                if (atualizado is null)
                {
                    NotificarErro("Nenhum Time foi encontrado com o id informado.");
                    return CustomResponse(ModelState);
                }

                return CustomResponse(atualizado, "Time atualizado com sucesso!");
            }
            else
            {

                ViewTimeDto atualizado = await timeApplication.PutAsync(putTimeDto, "", "", "", "", "");

                if (atualizado is null)
                {
                    NotificarErro("Nenhum Time foi encontrado com o id informado.");
                    return CustomResponse(ModelState);
                }

                return CustomResponse(atualizado, "Time atualizado com sucesso!");
            }
        }

        /// <summary>
        /// Exclui um Time.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um Time o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewTimeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewTimeDto removido = await timeApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhum Time foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "Time excluído com sucesso!");
        }
    }
}