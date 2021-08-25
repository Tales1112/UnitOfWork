using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity_Of_Work.Models;

namespace Unity_Of_Work.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Erros = new List<string>();
        public MainController() { }

        protected ActionResult CustomResponse(Notificator result)
        {
            if (result.ValidOperation())
            {
                return Ok(result);
            }

            switch (result.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                    {
                        {"Messages", result.Errors.ToArray() }
                    }));

                case HttpStatusCode.NotFound:
                    return NotFound(new ValidationProblemDetails(new Dictionary<string, string[]>
                    {
                        {"Messages", result.Errors.ToArray() }
                    }));

                case HttpStatusCode.InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, new ValidationProblemDetails(new Dictionary<string, string[]>
                    {
                        {"Messages", Erros.ToArray() }
                    }
                    ));

                default:
                    return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                    {
                        { "Messages", Erros.ToArray() }
                    }
                    ));
            }
        }
    }
}
