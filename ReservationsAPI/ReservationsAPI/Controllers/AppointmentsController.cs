using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;

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

        [HttpGet("doctor-appointments/{id}")]
        public async Task<IActionResult> GetDoctorAppointments(long id)
        {
            return Ok(await _appointmentsManager.GetDoctorAppointments(id));
        }

        [HttpGet("pacient-appointments/{id}")]
        public async Task<IActionResult> GetPacientAppointments(long id)
        {
            return Ok(await _appointmentsManager.GetPacientAppointments(id));
        }


        //        // PUT: api/Appointments/5
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutAppointment(long id, Appointment appointment)
        //        {
        //            if (id != appointment.DoctorId)
        //            {
        //                return BadRequest();
        //            }

        //            _context.Entry(appointment).State = EntityState.Modified;

        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!AppointmentExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return NoContent();
        //        }

        //        // POST: api/Appointments
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPost]
        //        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        //        {
        //            _context.Appointments.Add(appointment);
        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateException)
        //            {
        //                if (AppointmentExists(appointment.DoctorId))
        //                {
        //                    return Conflict();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return CreatedAtAction("GetAppointment", new { id = appointment.DoctorId }, appointment);
        //        }

        //        // DELETE: api/Appointments/5
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeleteAppointment(long id)
        //        {
        //            var appointment = await _context.Appointments.FindAsync(id);
        //            if (appointment == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.Appointments.Remove(appointment);
        //            await _context.SaveChangesAsync();

        //            return NoContent();
        //        }

        //        private bool AppointmentExists(long id)
        //        {
        //            return _context.Appointments.Any(e => e.DoctorId == id);
        //        }
    }
}
