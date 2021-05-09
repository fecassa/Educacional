using educacional.LayerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace educacional.LayerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;                

        public ReportController(educacional.LayerInfrastructure.AppContext context, IConfiguration configure)
        {            
            _reportService = new ReportService(context, configure.GetSection("ReportPath").Value );            
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetReport()
        {            
            string _reportUri = _reportService.CreateReport(User.Identity.Name);
            
            if(_reportUri.Equals(""))
                return  StatusCode(500);
            else
                return Ok(_reportUri);
        }
    }
}
