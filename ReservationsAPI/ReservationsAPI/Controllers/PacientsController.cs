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
    public class PacientsController : ControllerBase
    {
        private readonly ReservationsContext _context;

        public PacientsController(ReservationsContext context)
        {
            _context = context;
        }

        // GET: api/Pacients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pacient>>> GetPacients()
        {
            return await _context.Pacients.ToListAsync();
        }

        // GET: api/Pacients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pacient>> GetPacient(long id)
        {
            var pacient = await _context.Pacients.FindAsync(id);

            if (pacient == null)
            {
                return NotFound();
            }

            return pacient;
        }

        // PUT: api/Pacients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacient(long id, Pacient pacient)
        {
            if (id != pacient.Id)
            {
                return BadRequest();
            }

            _context.Entry(pacient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientExists(id))
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

        // POST: api/Pacients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pacient>> PostPacient(Pacient pacient)
        {
            _context.Pacients.Add(pacient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacient", new { id = pacient.Id }, pacient);
        }

        // DELETE: api/Pacients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacient(long id)
        {
            var pacient = await _context.Pacients.FindAsync(id);
            if (pacient == null)
            {
                return NotFound();
            }

            _context.Pacients.Remove(pacient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacientExists(long id)
        {
            return _context.Pacients.Any(e => e.Id == id);
        }
    }
}
