using Microsoft.AspNetCore.Mvc;

namespace Mmu.Rms.WebApi.Areas.Web.Controllers
{
    [Route("api/[controller]")]
    public class IndividualsController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetIndividualById(string id)
        {
            return Ok();
        }

        public IActionResult GetAllIndividuals()
        {
            return Ok();
        }
        

    }
}
