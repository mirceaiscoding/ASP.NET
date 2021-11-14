using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentsManager _appointmentsManager;

        public AppointmentsController(IAppointmentsManager appointmentsManager)
        {
            _appointmentsManager = appointmentsManager;
        }

        [HttpGet("get-doctor-appointments/{id}")]
        public async Task<IActionResult> GetDoctorAppointments(long id)
        {
            return Ok(await _appointmentsManager.GetDoctorAppointments(id));
        }

        [HttpGet("get-pacient-appointments/{id}")]
        public async Task<IActionResult> GetPacientAppointments(long id)
        {
            return Ok(await _appointmentsManager.GetPacientAppointments(id));
        }

        [HttpGet("get-all-appointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            return Ok(await _appointmentsManager.GetAll());
        }

        [HttpGet("get-appointment")]
        public async Task<IActionResult> GetAppointmentById(long pacientId, long doctorId, long procedureId, DateTime startTime)
        {
            try
            {
                var appointment = await _appointmentsManager.GetById(pacientId, doctorId, procedureId, startTime);
                return Ok(appointment);
            }
            catch
            {
                return BadRequest("One or more Ids do not match!");
            }
        }

        [HttpPost("insert-appointment")]
        public async Task<IActionResult> PostAppointment(AppointmentDTO appointmentDTO)
        {
            try
            {
                var insertedAppointmentDTO = await _appointmentsManager.Insert(appointmentDTO);
                return Ok(insertedAppointmentDTO);
            }
            catch
            {
                return BadRequest("One or more Ids do not match!");
            }
        }

        // The new EndTime will be set based on the old time span!
        [HttpPut("update-appointment-time")]
        public async Task<IActionResult> UpdateAppointment(long pacientId, long doctorId, long procedureId, DateTime startTime, DateTime newStartTime)
        {
            try
            {
                var updatedAppointmentDTO = await _appointmentsManager.UpdateTime(pacientId, doctorId, procedureId, startTime, newStartTime);
                return Ok(updatedAppointmentDTO);
            }
            catch
            {
                return BadRequest("One or more Ids do not match!");
            }
        }

        [HttpDelete("delete-appointment")]
        public async Task<IActionResult> DeleteAppointment(AppointmentDTO appointmentDTO)
        {
            try
            {
                var deletedAppointmentDTO = await _appointmentsManager.Delete(appointmentDTO);
                return Ok(deletedAppointmentDTO);
            }
            catch
            {
                return BadRequest("One or more Ids do not match!");
            }
        }
    }
}
