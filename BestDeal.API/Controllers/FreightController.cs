using BestDeal.API.ActionFilters;
using BestDeal.Core.Models;
using BestDeal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BestDeal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class FreightController : ControllerBase
    {
        private readonly IFreightService _service;
        public FreightController(IFreightService service)
        {
            _service = service;
        }

        // GET api/<FreightController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchParams parameters)
        {
                SearchResponse result = await _service.RunSearch(parameters);
                if (result != null)
                    return Ok(result);
                else
                    return NoContent();
        }

    }
}
