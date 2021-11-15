using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkDaySchedulesController : ControllerBase
    {
        private readonly IWorkDayScheduleManager _workDayScheduleManager;

        public WorkDaySchedulesController(IWorkDayScheduleManager workDayScheduleManager)
        {
            _workDayScheduleManager = workDayScheduleManager;
        }

        [HttpGet("get-doctor-work-schedule")]
        public async Task<IActionResult> GetWorkSchedule(long doctorId)
        {
            try
            {
                var workSchedule = await _workDayScheduleManager.GetWorkSchedule(doctorId);
                return Ok(workSchedule);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get-doctor-work-day-schedule")]
        public async Task<IActionResult> GetWorkDaySchedule(long doctorId, int dayOfWeek)
        {
            try
            {
                var workDaySchedule = await _workDayScheduleManager.GetWorkDaySchedule(doctorId, dayOfWeek);
                return Ok(workDaySchedule);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get-doctor-work-day-schedule-by-id")]
        public async Task<IActionResult> GetWorkDayScheduleById(long id)
        {
            try
            {
                var workDaySchedule = await _workDayScheduleManager.GetById(id);
                return Ok(workDaySchedule);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("insert-work-day-schedule")]
        public async Task<IActionResult> InsertWorkDaySchedule(WorkDaySchedulePostModel postModel)
        {
            try
            {
                var workDayScheduleDTO = new WorkDayScheduleDTO
                {
                    DayOfWeek = postModel.DayOfWeek,
                    DoctorId = postModel.DoctorId,
                    StartHour = TimeSpan.Parse(postModel.StartHour),
                    EndHour = TimeSpan.Parse(postModel.EndHour),
                    BreakStartHour = TimeSpan.Parse(postModel.BreakStartHour),
                    BreakEndHour = TimeSpan.Parse(postModel.BreakEndHour),
                };
                var insertedWorkDaySchedule = await _workDayScheduleManager.Insert(workDayScheduleDTO);
                return Ok(insertedWorkDaySchedule);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update-work-day-schedule")]
        public async Task<IActionResult> UpdateWorkDaySchedule(long id, WorkDaySchedulePostModel postModel)
        {
            try
            {
                var workDayScheduleDTO = new WorkDayScheduleDTO
                {
                    Id = postModel.Id,
                    DayOfWeek = postModel.DayOfWeek,
                    DoctorId = postModel.DoctorId,
                    StartHour = TimeSpan.Parse(postModel.StartHour),
                    EndHour = TimeSpan.Parse(postModel.EndHour),
                    BreakStartHour = TimeSpan.Parse(postModel.BreakStartHour),
                    BreakEndHour = TimeSpan.Parse(postModel.BreakEndHour),
                };
                var updatedWorkDaySchedule = await _workDayScheduleManager.Update(id, workDayScheduleDTO);
                return Ok(updatedWorkDaySchedule);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
