using System.Net;
using Microsoft.AspNetCore.Mvc;
using SoftPlan.WebApp.CalculoJuros.Api.AppServices.Interfaces;

namespace SoftPlan.WebApp.CalculoJuros.Api.Controllers
{
    [ApiController]
    public class CalculoJurosController : ApplicationControllerBase
    {
        private readonly ITaxaJurosAplicacaoService _taxaJurosService;

        public CalculoJurosController(ITaxaJurosAplicacaoService taxaJurosService)
            => _taxaJurosService = taxaJurosService;


        [HttpGet]
        [Route("calculojuros")]
        public IActionResult Get(decimal valorInicial, int meses)
        {

            try
            {
                var taxaJurosAplicacao = _taxaJurosService.ObterJurosTaxaAplicacao(valorInicial, meses);

                return FormatContentResultResponse(taxaJurosAplicacao);

            }
            catch (System.Exception ex)
            {
                var responseError = new
                {
                    statusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message
                };

                return FormatContentResultResponse(responseError);

            }


        }
    }
}
