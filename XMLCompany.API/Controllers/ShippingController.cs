using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMLCompany.API.Models;
using XMLCompany.API.Services;

namespace XMLCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : Controller
    {
        private readonly IShippingService _service;
        public ShippingController(IShippingService service)
        {
            _service = service;
        }

        // GET api/<ShippingController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ParamsModel parameters)
        {
            ResponseModel result = _service.GetDeal(parameters);
            return Ok(result);
        }
    }
}
