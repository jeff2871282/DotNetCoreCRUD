using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreCRUD.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace DotNetCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        public ErrorController()
        {
        }

        [HttpGet("/error")]
        public ActionResult Error([FromServices] IHostEnvironment webhostenvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDev = webhostenvironment.IsDevelopment();
            var problemdetail = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = "error",
                Detail = isDev ? ex.StackTrace : null
            };
            return StatusCode(problemdetail.Status.Value,problemdetail);
        }
    }
}