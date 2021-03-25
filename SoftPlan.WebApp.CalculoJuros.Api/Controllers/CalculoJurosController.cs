using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoftPlan.WebApp.CalculoJuros.Api.AppServices;

namespace SoftPlan.WebApp.CalculoJuros.Api.Controllers
{
    [ApiController]
    public class CalculoJurosController : ApplicationControllerBase
    {
        private readonly TaxaJurosAplicacaoService _taxaJurosService;

        public CalculoJurosController(TaxaJurosAplicacaoService taxaJurosService)
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
