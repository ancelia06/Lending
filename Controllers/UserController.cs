using Lending_CapstoneProject.DTOs;
using Lending_CapstoneProject.Models;
using Lending_CapstoneProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lending_CapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Endpoint for customer registration
        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegistrationDto customerRegistrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.RegisterUserAsync(customerRegistrationDto, UserType.Customer);
            if (!result)
            {
                return Conflict("User with this email already exists.");
            }

            return Ok("User registered successfully.");
        }

        // Endpoint for user login (for all user types)
        // POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _userService.LoginAsync(loginDto);
            if (token == null)
            {
                return Unauthorized("Invalid username/email or password.");
            }

            // In a real application, you would return the generated token here.
            return Ok(new { Message = "Login successful", Token = token });
        }

    }
}
