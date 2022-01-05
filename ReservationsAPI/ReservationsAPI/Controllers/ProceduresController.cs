using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private readonly IProceduresManager _proceduresManager;

        public ProceduresController(IProceduresManager proceduresManager)
        {
            _proceduresManager = proceduresManager;
        }

        [HttpGet("get-all-procedures")]
        public async Task<IActionResult> GetAllProcedures()
        {
            return Ok(await _proceduresManager.GetAll());
        }

        [HttpGet("get-procedure-by-id/{id}")]
        public async Task<IActionResult> GetProcedureById(long id)
        {
            try
            {
                return Ok(await _proceduresManager.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("insert-procedure")]
        public async Task<IActionResult> InsertProcedure(ProcedureDTO procedureDTO)
        {
            try
            {
                var insertedProcedureDTO = await _proceduresManager.Insert(procedureDTO);
                return Ok(insertedProcedureDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update-procedure")]
        public async Task<IActionResult> UpdateProcedure(long id, ProcedureDTO procedureDTO)
        {
            try
            {
                var updatedProcedure = await _proceduresManager.Update(id, procedureDTO);
                return Ok(updatedProcedure);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update-procedure-cost")]
        public async Task<IActionResult> UpdateProcedureCost(long id, int newCost)
        {
            try
            {
                var updatedProcedure = await _proceduresManager.UpdateCost(id, newCost);
                return Ok(updatedProcedure);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete-procedure/{id}")]
        public async Task<IActionResult> DeleteProcedure(long id)
        {
            try
            {
                var result = await _proceduresManager.Delete(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
