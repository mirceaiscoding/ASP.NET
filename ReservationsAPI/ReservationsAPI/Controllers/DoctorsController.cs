using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsManager _doctorsManager;

        public DoctorsController(IDoctorsManager doctorsManager)
        {
            _doctorsManager = doctorsManager;
        }

        [HttpGet("get-is-working")]
        public async Task<IActionResult> GetNumberOfFutureAppointments(long doctorId, DateTime date)
        {
            return Ok(await _doctorsManager.IsWorking(doctorId, date));
        }

        [HttpPost("insert-doctor")]
        public async Task<IActionResult> InsertDoctor(DoctorDTO doctorDTO)
        {
            try
            {
                var insertedDoctorDTO = await _doctorsManager.Insert(doctorDTO);
                return Ok(insertedDoctorDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
