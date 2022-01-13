using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IWorkDayScheduleManager
    {
        Task<List<WorkDayScheduleDTO>> GetWorkSchedule(long doctorId);

        Task<WorkDayScheduleDTO> GetWorkDaySchedule(long doctorId, int day);

        Task<List<WorkDayScheduleDTO>> GetAll();

        Task<WorkDayScheduleDTO> GetById(long id);

        Task<WorkDayScheduleDTO> Insert(WorkDayScheduleDTO workDayScheduleDTO);

        Task<WorkDayScheduleDTO> Update(long id, WorkDayScheduleDTO workDayScheduleDTO);

        Task<WorkDayScheduleDTO> Delete(WorkDayScheduleDTO workDayScheduleDTO);
    }
}
