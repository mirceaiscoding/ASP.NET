using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.BLL.Interfaces;

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

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _proceduresManager.GetAll();
            return Ok(appointments);
        }
    }
}
