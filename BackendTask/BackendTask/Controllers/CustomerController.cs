using BackendTask.Entities;
using BackendTask.Services.Abstracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BackendTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
                var customers = await _customerRepository.GetAllAsync();
            if(customers is { })
            {
                return Ok(customers);
            }
            return BadRequest("Müştəri siyahısı boşdur");
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            if (customer is { })
            {
            await _customerRepository.Add(customer);
            return Ok(customer);
            }
              return BadRequest("Zəhmət olmasa məlumatları düzgün daxil edin");
        }
    }
}
