using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Models;

namespace ReservationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkDaySchedulesController : ControllerBase
    {
        private readonly ReservationsContext _context;

        public WorkDaySchedulesController(ReservationsContext context)
        {
            _context = context;
        }

        // GET: api/WorkDaySchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkDaySchedule>>> GetWorkDaySchedules()
        {
            return await _context.WorkDaySchedules.ToListAsync();
        }

        // GET: api/WorkDaySchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkDaySchedule>> GetWorkDaySchedule(long id)
        {
            var workDaySchedule = await _context.WorkDaySchedules.FindAsync(id);

            if (workDaySchedule == null)
            {
                return NotFound();
            }

            return workDaySchedule;
        }

        // PUT: api/WorkDaySchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkDaySchedule(long id, WorkDaySchedule workDaySchedule)
        {
            if (id != workDaySchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(workDaySchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkDayScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorkDaySchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkDaySchedule>> PostWorkDaySchedule(WorkDaySchedule workDaySchedule)
        {
            _context.WorkDaySchedules.Add(workDaySchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkDaySchedule", new { id = workDaySchedule.Id }, workDaySchedule);
        }

        // DELETE: api/WorkDaySchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkDaySchedule(long id)
        {
            var workDaySchedule = await _context.WorkDaySchedules.FindAsync(id);
            if (workDaySchedule == null)
            {
                return NotFound();
            }

            _context.WorkDaySchedules.Remove(workDaySchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkDayScheduleExists(long id)
        {
            return _context.WorkDaySchedules.Any(e => e.Id == id);
        }
    }
}
