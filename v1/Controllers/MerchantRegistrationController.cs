using Microsoft.AspNetCore.Mvc;
using v1.DTOs;
using v1.Services.IService;

namespace v1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantRegistrationController : ControllerBase
    {
        private readonly IMerchantRegistrationServiceInterface _merchantRegistrationService;

        public MerchantRegistrationController(IMerchantRegistrationServiceInterface merchantRegistrationService)
        {
            _merchantRegistrationService = merchantRegistrationService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterMerchant([FromBody] MerchantRegistrationDto merchantRegistrationDto)
        {
            if (merchantRegistrationDto == null)
            {
                return BadRequest("Invalid request data.");
            }

            try
            {
                // Call the service to handle the registration
                await _merchantRegistrationService.RegisterMerchantAsync(merchantRegistrationDto);

                // Return a success response
                return Ok(new { Message = "Merchant registration successful." });
            }
            catch (ArgumentException ex)
            {
                // Handle invalid input (e.g., invalid merchant or card type)
                return BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                // Handle business logic errors (e.g., user creation failed)
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }
        
    }
}

