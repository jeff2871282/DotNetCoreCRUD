using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreCRUD.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static DotNetCoreCRUD.Models.login;
//using DotNetCoreCRUD.Models;

namespace DotNetCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        private readonly JwtHelpers jwt;
        public AccountController(ILogger<AccountController> logger, JwtHelpers jwt)
        {
            this.jwt = jwt;
            this.logger = logger;
        }

        [HttpPost("")]
        public ActionResult<loginResult> GetTModels(loginModels login)
        {
            var result = new loginResult();
            result.token = jwt.GenerateToken(login.username);
            return result;
        }
    }
}