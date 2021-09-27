using CompanyTwo.API.Models;
using CompanyTwo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTwo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsignmentController : Controller
    {
        private readonly IConsignmentService _service;
        public ConsignmentController(IConsignmentService service)
        {
            _service = service;
        }

        // GET api/<ConsignmentController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ConsignmentInputModel parameters)
        {
            ConsignmentOutputModel result = _service.GetDeal(parameters);
            return Ok(result);
        }
    }
}
