using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authManager.Register(registerModel);
            if (result)
            {
                return Ok("Registered");
            }
            else
            {
                return BadRequest("Not registered");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authManager.Login(loginModel);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshModel refreshModel)
        {
            var result = await _authManager.Refresh(refreshModel);
            return Ok(result);
        }


    }
}
