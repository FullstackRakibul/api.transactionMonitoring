﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using v1.DbContexts.AuthModels;
using v1.DTOs.AuthDTO;
using v1.Services.AuthService;

namespace v1.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(AuthService authService, SignInManager<ApplicationUser> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var result = await _authService.RegisterAsync(request.Email, request.Password, request.Name);
            return result ? Ok("User registered successfully") : BadRequest("User registration failed");
            //return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var (success, token, errorMessage) = await _authService.LoginAsync(request.Email, request.Password);
            return success ? Ok(new { token }) : Unauthorized(new { message = errorMessage });

        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("User logged out successfully");
        }
    }
}
