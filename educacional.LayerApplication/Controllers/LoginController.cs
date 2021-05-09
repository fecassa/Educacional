using educacional.LayerDomain.Model;
using educacional.LayerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educacional.LayerApplication.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(educacional.LayerInfrastructure.AppContext context)
        {
            _loginService = new LoginService(context);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetToken([FromBody] User user)
        {
            var _token = _loginService.GetToken(user);

            if(_token.TokenAccess != null)
                return Ok(_token);
            else
                return Unauthorized();
        }
    }
}
