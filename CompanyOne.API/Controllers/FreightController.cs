using CompanyOne.API.Models;
using CompanyOne.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreightController : ControllerBase
    {
        private readonly IFreightService _service;
        public FreightController(IFreightService service)
        {
            _service = service;
        }

        // GET api/<FreightController>/contactAddress/wharehouseAddress
        [HttpGet("{contactAddress}/{wharehouseAddress}")]
        public async Task<IActionResult> Get(string contactAddress, string wharehouseAddress, [FromQuery] List<int> dimensions)
        {
            var param = new InputModel() { ContactAddress=contactAddress, WharehouseAddress=wharehouseAddress, Dimensions=dimensions };
            OutputModel result = _service.GetDeal(param);
            return Ok(result);
        }

                
    }
}
