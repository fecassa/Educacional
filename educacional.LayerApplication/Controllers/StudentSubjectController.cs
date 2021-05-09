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
    public class StudentSubjectController : ControllerBase
    {
        private readonly StudentSubjectService _studentsubjectService;        

        public StudentSubjectController(educacional.LayerInfrastructure.AppContext context)
        {
            _studentsubjectService = new StudentSubjectService(context);
        }

        [HttpGet]
        [Authorize]
        public IActionResult InsertDataStudentSubject()
        {
            try
            {
                _studentsubjectService.CreateStudentSubject();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            };
        }
    }
}
