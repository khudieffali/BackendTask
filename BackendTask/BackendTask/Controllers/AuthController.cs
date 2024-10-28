using BackendTask.Entities;
using BackendTask.Security;
using BackendTask.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserRepository userRepository, IConfiguration config) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IConfiguration _config = config;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string email)
        {
            foreach (var item in await _userRepository.GetAllAsync())
            {
                if(email == item.Email)
                {
                    var token = TokenHandler.CreateToken(_config,email);
                    return Ok(new { Token = token });
                }
            }
            return Unauthorized("Bu email qeydiyyatdan keçməmişdir");
        }
    }
}
