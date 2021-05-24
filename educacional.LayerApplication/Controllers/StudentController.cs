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
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        //private readonly AppDbContext _context;

        public StudentController(educacional.LayerInfrastructure.AppContext context)
        {
            _studentService = new StudentService(context);
        }

        [HttpGet]
        [Authorize]        
        public IActionResult InsertDataStudents()
        {
            try
            {
                _studentService.CreateStudents();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }            
        }

        [HttpGet]
        [Route("~/Address")]
        public IActionResult GetAddress()
        {
            _studentService.GetAddress();
            return Ok();
        }
    }
}
