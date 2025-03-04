using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserProject.Data;
using UserProject.Model;
using UserProject.Services;

namespace UserProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var result = await _userService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> PostUser(User user)
        {
            try
            {
                bool isAdded = await _userService.AddNewUser(user);
                if (!isAdded)
                {
                    return BadRequest(new { error = "Email already exists" });
                }

                await _userService.AddNewUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
