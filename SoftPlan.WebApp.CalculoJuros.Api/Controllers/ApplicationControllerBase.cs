using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SoftPlan.WebApp.CalculoJuros.Api.Controllers
{
    public class ApplicationControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult FormatContentResultResponse(object data, string contentType = "application/json")
        {
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(data),
                ContentType = contentType
            };
        }
    }
}
