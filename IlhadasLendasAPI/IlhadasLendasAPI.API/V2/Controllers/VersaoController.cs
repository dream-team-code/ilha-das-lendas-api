using Microsoft.AspNetCore.Mvc;

namespace IlhadasLendasAPI.API.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("/v{version:apiVersion}/versao")]
    [ApiController]
    public class VersaoController : ControllerBase
    {
        private const string versao = "Esta é a versão V2.";

        public VersaoController()
        {
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
    }
}