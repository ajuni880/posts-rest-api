using Microsoft.AspNetCore.Mvc;
using PostsAPI.Application.Dtos;
using PostsAPI.Application.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace PostsAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;

        public AuthController(IIdentityService identityService, IJwtService jwtService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthDto authDto)
        {
            await _identityService.CreateUserAsync(authDto);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDto authDto)
        {
            var userId = await _identityService.LogInAsync(authDto);
            if (userId == null)
                return Unauthorized();

            var token = _jwtService.GenerateToken(userId);
            return Ok(new { token });
        }
    }
}
