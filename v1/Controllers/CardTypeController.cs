using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using v1.DTOs;
using v1.Services;
using v1.Services.IService;

namespace v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypeController : ControllerBase
    {


        private readonly ICardTypeServiceInterface _cardTypeService;

        public CardTypeController(ICardTypeServiceInterface cardTypeService)
        {
            _cardTypeService = cardTypeService;
        }

        // POST: api/cardtype
        [HttpPost]
        public async Task<IActionResult> CreateCardType([FromBody] CardTypeDto dto)
        {
            // Use a hardcoded username for this example; in a real app, retrieve it from the auth context.
            string currentUser = "System";
            try
            {
                var result = await _cardTypeService.CreateCardTypeAsync(dto, currentUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/cardtype
        [HttpGet]
        public async Task<IActionResult> GetAllCardTypes()
        {
            IEnumerable<CardTypeDto> result = await _cardTypeService.GetAllCardTypesAsync();
            return Ok(result);
        }
    }
}
