using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManage;

        public AuthController(IAuthManager authManager)
        {
            _authManage = authManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            var result = await _authManage.Register(registerModel);
            if (result)
            {
                return Ok("Registered");
            }
            else
            {
                return BadRequest("Not registered");
            }
        }

    }
}
