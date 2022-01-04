﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly IPacientsManager _pacientsManager;
        private readonly IDoctorsManager _doctorsManager;

        public AuthController(IAuthManager authManager, IPacientsManager pacientsManager, IDoctorsManager doctorsManager)
        {
            _authManager = authManager;
            _pacientsManager = pacientsManager;
            _doctorsManager = doctorsManager;
        }

        //[Authorize("Admin")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authManager.Register(registerModel);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("register-as-pacient")]
        public async Task<IActionResult> RegisterAsPacient([FromBody] PacientUserPostModel pacientUserPostModel)
        {
            var userId = await _authManager.RegisterAsPacient(pacientUserPostModel.registerModel);
            if (userId == null)
            {
                return Ok(false);
            }
            pacientUserPostModel.PacientDTO.UserId = userId.Value;
            var insertedPacientDTO = await _pacientsManager.Insert(pacientUserPostModel.PacientDTO);
            return Ok(true);
        }

        //[Authorize("Admin")]
        [HttpPost("register-as-doctor")]
        public async Task<IActionResult> RegisterAsDoctor([FromBody] DoctorUserPostModel pacientUserPostModel)
        {
            var userId = await _authManager.RegisterAsPacient(pacientUserPostModel.registerModel);
            if (userId == null)
            {
                return Ok(false);
            }
            pacientUserPostModel.doctorDTO.UserId = userId.Value;
            var insertedPacientDTO = await _doctorsManager.Insert(pacientUserPostModel.doctorDTO);
            return Ok(true);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authManager.Login(loginModel);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshModel refreshModel)
        {
            var result = await _authManager.Refresh(refreshModel);
            return Ok(result);
        }


    }
}
