using Microsoft.AspNetCore.Mvc;

namespace v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        // GET
        [HttpGet]
        public async Task<IActionResult> CollectionMetricsSummary()
        {
            return Ok(new { message = "Hello from Merchant Registration!" });
        }
    }
}
