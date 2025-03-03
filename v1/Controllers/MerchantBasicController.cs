using Microsoft.AspNetCore.Mvc;

namespace v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantBasicController : ControllerBase
    {
    
        [HttpPost("create")]
        public async Task<IActionResult> CreateBasicMerchantAsync()
        {
            return Ok("MerchantBasicController  ");
        }
    }
}

