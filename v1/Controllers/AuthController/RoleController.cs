using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using v1.DTOs.AuthDTO;
using v1.Services.AuthService;

namespace v1.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequestDto request)
        {
            var result = await _roleService.CreateRoleAsync(request.RoleName, request.Description);
            return result ? Ok("Role created successfully") : BadRequest("Role already exists or failed to create");
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequestDto request)
        {
            var result = await _roleService.AssignRoleAsync(request.UserId, request.RoleName);
            return result ? Ok("Role assigned successfully") : BadRequest("Failed to assign role");
        }
    }

}
