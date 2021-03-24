
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoftPlan.Fianceiro.Domain.Entities;

namespace SoftPlan.WebApp.TaxaJuros.Api.Controllers
{
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
       
        [HttpGet]
        [Route("taxajuros")]
        public IActionResult Get()
        {
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(new JurosTaxa()),
                ContentType = "application/json"
            };
         
        }
    }
}
