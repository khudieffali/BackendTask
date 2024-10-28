using BackendTask.Entities;
using BackendTask.Services.Abstracts;
using BackendTask.Services.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAllAsync();
            if (users is { })
            {
                return Ok(users);
            }
            return BadRequest("Istifadəçi siyahısı boşdur");
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user is { })
            {
                await _userRepository.Add(user);
                return Ok(new
                {
                    message="Uğurla qeydiyyatdan keçdiniz",
                    user
                });
            }
            return BadRequest("Zəhmət olmasa məlumatları düzgün daxil edin");
        }
    }
}
