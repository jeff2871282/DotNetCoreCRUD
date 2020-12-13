using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreCRUD.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace DotNetCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IOptions<JwtSettings> options;
        private readonly ILogger logger;
        public ConfigController(IOptions<JwtSettings> options, ILogger<ConfigController> logger)
        {
            this.logger = logger;
            this.options = options;

        }

        [HttpGet("")]
        public string GetTModels()
        {
            logger.LogTrace("Trace");
            logger.LogDebug("Debug");
            logger.LogInformation("Info");
            logger.LogWarning("Warn");
            logger.LogError("error");
            logger.LogCritical("crit");

            return options.Value.Issuer;
        }
    }
}