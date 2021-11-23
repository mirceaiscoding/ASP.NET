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
    public class PacientsController : ControllerBase
    {
        private readonly IPacientsManager _pacientsManager;

        public PacientsController(IPacientsManager pacientsManager)
        {
            _pacientsManager = pacientsManager;
        }

        [HttpGet("get-number-of-future-appointments")]
        public async Task<IActionResult> GetNumberOfFutureAppointments(long pacientId)
        {
            try
            {
                var numberOfFutureAppointments = await _pacientsManager.GetNumberOfFutureAppointments(pacientId);
                return Ok(numberOfFutureAppointments);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("insert-pacient")]
        public async Task<IActionResult> InsertPacient(PacientDTO pacientDTO)
        {
            try
            {
                var insertedDoctorDTO = await _pacientsManager.Insert(pacientDTO);
                return Ok(insertedDoctorDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
