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

        [HttpGet("get-all-doctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            return Ok(await _doctorsManager.GetAll());
        }

        [HttpGet("get-doctor-by-id/{id}")]
        public async Task<IActionResult> GetDoctorById(long id)
        {
            try
            {
                return Ok(await _doctorsManager.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete-doctor")]
        public async Task<IActionResult> DeleteDoctor(DoctorDTO doctorDTO)
        {
            try
            {
                var deletedDoctorDto = await _doctorsManager.Delete(doctorDTO);
                return Ok(deletedDoctorDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
