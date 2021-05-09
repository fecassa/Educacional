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
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService _subjectService;        

        public SubjectController(educacional.LayerInfrastructure.AppContext context)
        {
            _subjectService = new SubjectService(context);
        }

        [HttpGet]
        [Authorize]
        public IActionResult InsertDataSubject()
        {
            try
            {
                _subjectService.CreateSubject();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
