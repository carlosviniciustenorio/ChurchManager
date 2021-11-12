using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManager.API.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Get([FromServices] IWebHostEnvironment env)
        {
            if (env.EnvironmentName != "Development")
                return Problem();

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            return Problem(detail: exception.StackTrace, 
                           title: exception.Message, 
                           type: exception.GetType().Name);
        }
    }
}
