using IlhadasLendasAPI.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace IlhadasLendasAPI.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/versao")]
    [ApiController]
    public class VersaoController : ControllerBase
    {
        private readonly Ambiente ambiente;
        private const string versao = "Esta é a versão V1.";
        public readonly IWebHostEnvironment webHostEnvironment;

        public VersaoController(IWebHostEnvironment environment)
        {
            webHostEnvironment = environment;

            ambiente = environment.IsProduction() ? Ambiente.Producao :
              environment.IsStaging() ? Ambiente.Homologacao : Ambiente.Desenvolvimento;
        }

        /// <summary>
        /// Informa a versão da API.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public string Valor()
        {
            return versao;
        }

        /// <summary>
        /// Informa o ambiente da API.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ambiente")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public string AmbienteAtual()
        {
            return ambiente.ToString();
        }

        /// <summary>
        /// Informa o root da API.
        /// </summary>
        /// <returns></returns>
        [HttpGet("apiroot")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public string Root()
        {
            string _webRootPath = webHostEnvironment.WebRootPath;
            string _contentRootPath = webHostEnvironment.ContentRootPath;

            string result = _webRootPath + " / " + _contentRootPath;

            return result;
        }
    }
}