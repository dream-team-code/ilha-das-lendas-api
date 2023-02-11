using IlhadasLendasAPI.API.Controllers;
using IlhadasLendasAPI.Application.Dtos.Base;
using IlhadasLendasAPI.Application.Dtos.Jogador;
using IlhadasLendasAPI.Application.Dtos.Pagination;
using IlhadasLendasAPI.Application.Interfaces;
using IlhadasLendasAPI.Application.Utilities.Image;
using IlhadasLendasAPI.Application.Utilities.Paths;
using IlhadasLendasAPI.Domain.Core;
using IlhadasLendasAPI.Domain.Core.Notifier;
using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Domain.Enum;
using IlhadasLendasAPI.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace IlhadasLendasAPI.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/Jogadores")]
    [ApiController]
    public class JogadorController : MainController
    {
        private readonly IJogadorApplication jogadorApplication;
        private readonly Ambiente Ambiente;

        public JogadorController(IJogadorApplication jogadorApplication,
                                 IWebHostEnvironment webHostEnvironment,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.jogadorApplication = jogadorApplication;
            Ambiente = webHostEnvironment.IsProduction() ? Ambiente.Producao : webHostEnvironment.IsStaging() ? Ambiente.Homologacao : Ambiente.Desenvolvimento;
        }

        /// <summary>
        /// Retorna todos os Jogadores com filtro e paginação de dados.
        /// </summary>
        /// <param name="parametersJogador"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<Jogador, ViewJogadorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersJogador parametersJogador)
        {
            ViewPagedListDto<Jogador, ViewJogadorDto> result = await jogadorApplication.GetPaginationAsync(parametersJogador);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhum Jogador foi encontrado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "Jogadors encontrados.");
        }

        /// <summary>
        /// Insere um Jogador.
        /// </summary>
        /// <param name="postJogadorDto"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewJogadorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostJogadorDto postJogadorDto, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (!await PathSystem.ValidateURLs(diretorio.ToString(), Ambiente))
            {
                NotificarErro("Diretório não encontrado.");
                return CustomResponse(ModelState);
            }

            Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorio.ToString(), Ambiente);

            string extensao = ExtensionSystem.GetExtensaoB64(postJogadorDto.ImagemBase64);
            string base64String = ExtensionSystem.GetB64String(postJogadorDto.ImagemBase64);

            if (extensao is null || base64String is null)
            {
                NotificarErro("Extensão não suportada ou texto não se encontra em Base64.");
                return CustomResponse(ModelState);
            }

            ViewJogadorDto inserido = await jogadorApplication.PostAsync(postJogadorDto, Urls["IP"], Urls["DNS"], Urls["SPLIT"], base64String, extensao);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir o Jogador.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "Jogador criado com sucesso!");
        }

        /// <summary>
        /// Altera um Jogador.
        /// </summary>
        /// <param name="putJogadorDto"></param>
        /// <param name="diretorio"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewJogadorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] PutJogadorDto putJogadorDto, Diretorios diretorio)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (!string.IsNullOrWhiteSpace(putJogadorDto.ImagemBase64))
            {
                if (!await PathSystem.ValidateURLs(diretorio.ToString(), Ambiente))
                {
                    NotificarErro("Diretório não encontrado.");
                    return CustomResponse(ModelState);
                }

                Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorio.ToString(), Ambiente);

                string extensao = ExtensionSystem.GetExtensaoB64(putJogadorDto.ImagemBase64);
                string base64String = ExtensionSystem.GetB64String(putJogadorDto.ImagemBase64);

                if (extensao is null || base64String is null)
                {
                    NotificarErro("Extensão não suportada ou texto não se encontra em base64.");
                    return CustomResponse(ModelState);
                }

                ViewJogadorDto atualizado = await jogadorApplication.PutAsync(putJogadorDto, Urls["IP"], Urls["DNS"], Urls["SPLIT"], base64String, extensao);

                if (atualizado is null)
                {
                    NotificarErro("Nenhum Jogador foi encontrado com o id informado.");
                    return CustomResponse(ModelState);
                }

                return CustomResponse(atualizado, "Jogador atualizado com sucesso!");
            }
            else
            {

                ViewJogadorDto atualizado = await jogadorApplication.PutAsync(putJogadorDto, "", "", "", "", "");

                if (atualizado is null)
                {
                    NotificarErro("Nenhum Jogador foi encontrado com o id informado.");
                    return CustomResponse(ModelState);
                }

                return CustomResponse(atualizado, "Jogador atualizado com sucesso!");
            }
        }

        /// <summary>
        /// Exclui um Jogador.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um Jogador o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewJogadorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewJogadorDto removido = await jogadorApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhum Jogador foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "Jogador excluído com sucesso!");
        }
    }
}
