using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium1.Models;
using Kolokwium1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        public IProjectDService _service;
        public ProjectsController(IProjectDService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult GetTask (int id) {
            List<MyTask> list = _service.GetProjectInfo(id);
            if (!list.Any()) return NotFound("nie znaleziono zadan");//jesli lista pusta

            return Ok(list);
        }
    }
}