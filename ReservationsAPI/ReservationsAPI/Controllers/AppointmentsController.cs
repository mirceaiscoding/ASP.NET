using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentsManager _appointmentsManager;

        private readonly IPacientsManager _pacientsManager;

        public AppointmentsController(IAppointmentsManager appointmentsManager, IPacientsManager pacientsManager)
        {
            _appointmentsManager = appointmentsManager;
            _pacientsManager = pacientsManager;
        }

        [Authorize("Admin")]
        [HttpGet("get-doctor-appointments/{id}")]
        public async Task<IActionResult> GetDoctorAppointments(long id)
        {
            return Ok(await _appointmentsManager.GetDoctorAppointments(id));
        }

        [Authorize("Pacient")]
        [HttpGet("get-pacient-appointments/{pacientId}")]
        public async Task<IActionResult> GetPacientAppointments(long pacientId)
        {
            try
            {
                int authentifiedUserId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                PacientDTO authentifiedPacient = await _pacientsManager.GetUserData(authentifiedUserId);
                if (pacientId != authentifiedPacient.Id)
                {
                    return Unauthorized("Cannot acces data that isn't bound to this account");
                }
                var numberOfFutureAppointments = await _pacientsManager.GetNumberOfFutureAppointments(pacientId);
                return Ok(await _appointmentsManager.GetPacientAppointments(pacientId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

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

        [Authorize("Admin")]
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
        [Authorize("Admin")]
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

        [Authorize("Admin")]
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
