using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using v1.DTOs;
using v1.Services;
using v1.Services.IService;

namespace v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonCollectionController : ControllerBase
    {
        private readonly ICommonCollectionServiceInterface _service;

        public CommonCollectionController(ICommonCollectionServiceInterface service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCommonCollectionDto dto)
        {
            var createdBy = "System"; 
            var result = await _service.CreateAsync(dto, createdBy);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            var deletedBy = "System";
            var result = await _service.SoftDeleteAsync(id, deletedBy);
            return result ? Ok("Deleted successfully") : NotFound("Record not found");
        }
    }
}

