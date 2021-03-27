using Microsoft.AspNetCore.Mvc;
using Providers.GitPath.Interface;

namespace SoftPlan.WebApp.CalculoJuros.Api.Controllers
{
    [ApiController]
    public class HomeController : ApplicationControllerBase
    {
        private readonly IGitDiretorioRemotoService _gitDiretorioRemotoService;

        public HomeController(IGitDiretorioRemotoService gitDiretorioRemotoService)
            => _gitDiretorioRemotoService = gitDiretorioRemotoService;


        [HttpGet]
        [Route("/showmethecode")]
        public IActionResult Get()
        {
           var urlGithub =  _gitDiretorioRemotoService.ObterUrlGithub();

            var responseData = new
            {
                UrlGithub = _gitDiretorioRemotoService.FormatarUrlGithub(urlGithub)
            };

            return FormatContentResultResponse(responseData);
        }
    }
}
