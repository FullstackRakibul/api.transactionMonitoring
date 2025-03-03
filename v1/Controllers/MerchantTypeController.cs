using Microsoft.AspNetCore.Mvc;
using v1.DTOs;
using v1.Services.IService;

namespace v1.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class MerchantTypeController : ControllerBase
{
    private readonly IMerchantTypeServiceInterface _merchantTypeServiceInterface;

    public MerchantTypeController(IMerchantTypeServiceInterface merchantTypeServiceInterface)
    {
        _merchantTypeServiceInterface = merchantTypeServiceInterface;
    }
    
    
    // POST: api/merchanttype
    [HttpPost]
    public async Task<IActionResult> CreateMerchantType([FromBody] MerchantTypeDto dto)
    {
        // user info from your authentication context.
        string currentUser = "System";
        try
        {
            var result = await _merchantTypeServiceInterface.CreateMerchantTypeAsync(dto, currentUser);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // GET: api/merchanttype
    [HttpGet]
    public async Task<IActionResult> GetAllMerchantTypes()
    {
        var result = await _merchantTypeServiceInterface.GetAllMerchantTypesAsync();
        return Ok(result);
    }
    
}
}
