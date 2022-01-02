using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Models;
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

        [Authorize("Admin")]
        [HttpGet("get-all-appointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            return Ok(await _appointmentsManager.GetAll());
        }

        [Authorize("Admin")]
        [HttpGet("get-upcoming-appointments")]
        public async Task<IActionResult> getUpcomingAppointments()
        {
            return Ok(await _appointmentsManager.GetAllUpcoming());
        }

        [Authorize("Admin")]
        [HttpGet("get-previous-appointments")]
        public async Task<IActionResult> getPreviousAppointments()
        {
            return Ok(await _appointmentsManager.GetAllPrevious());
        }

        [Authorize("Admin")]
        [HttpGet("get-appointment")]
        public async Task<IActionResult> GetAppointmentById(long pacientId, long doctorId, long procedureId, DateTime startTime)
        {
            try
            {
                var appointment = await _appointmentsManager.GetById(pacientId, doctorId, procedureId, startTime);
                return Ok(appointment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPost("get-appointment-information")]
        public async Task<IActionResult> GetAppointmentInformationById(AppointmentDTO appointment)
        {
            try
            {
                var appointmentInfo = await _appointmentsManager.GetAppointmentInformationById(appointment.PacientId, appointment.DoctorId, appointment.ProcedureId, appointment.StartTime);
                return Ok(appointmentInfo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // The new EndTime will be set based on the old time span!
        [HttpPut("update-appointment-time")]
        public async Task<IActionResult> UpdateAppointment(NewStartTimeAppointmentModel startTimeAppointmentModel)
        {
            try
            {
                var updatedAppointmentDTO = await _appointmentsManager.UpdateTime(startTimeAppointmentModel.PacientId, startTimeAppointmentModel.DoctorId, startTimeAppointmentModel.ProcedureId, startTimeAppointmentModel.StartTime, startTimeAppointmentModel.NewStartTime);
                return Ok(updatedAppointmentDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
