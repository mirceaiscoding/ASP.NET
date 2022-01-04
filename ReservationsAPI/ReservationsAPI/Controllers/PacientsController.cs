using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.BLL.Interfaces;
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

        [HttpGet("get-all-pacients")]
        public async Task<IActionResult> GetAllPacients()
        {
            return Ok(await _pacientsManager.GetAll());
        }

        [Authorize("Pacient")]
        [HttpGet("get-user-data/{userId}")]
        public async Task<IActionResult> GetUserData(int userId)
        {
            try
            {
                int authentifiedUserId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                if (authentifiedUserId != userId)
                {
                    return Unauthorized("Cannot acces data that isn't bound to this account");
                }
                var pacient = await _pacientsManager.GetUserData(userId);
                return Ok(pacient);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

        [HttpPut("update-pacient")]
        public async Task<IActionResult> UpdatePacient(long id, PacientDTO pacientDTO)
        {
            try
            {
                var updatedPacient = await _pacientsManager.Update(id, pacientDTO);
                return Ok(updatedPacient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete-pacient")]
        public async Task<IActionResult> DeletePacient(PacientDTO pacientDTO)
        {
            try
            {
                var deletedPacientDto = await _pacientsManager.Delete(pacientDTO);
                return Ok(deletedPacientDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

