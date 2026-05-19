using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTOs;
using FitnessCenter.Services;
using BLL.DTO;

namespace FitnessCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = _authService.Login(request);

                return Ok(new
                {
                    token = token
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    message = ex.Message
                });
            }
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            try
            {
                var result = _authService.Register(request);

                // Return 201 Created on success
                return Created(string.Empty, new
                {
                    message = result
                });
            }
            catch (Exception ex)
            {
                // Return 400 Bad Request on error
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
        
    }
}
