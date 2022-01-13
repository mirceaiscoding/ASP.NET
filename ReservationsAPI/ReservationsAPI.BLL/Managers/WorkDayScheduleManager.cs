using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Managers
{
    public class WorkDayScheduleManager : IWorkDayScheduleManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkDayScheduleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WorkDayScheduleDTO> Insert(WorkDayScheduleDTO workDayScheduleDTO)
        {
            if (await _unitOfWork.DoctorsRepository.GetByIdAsync(workDayScheduleDTO.DoctorId) == null)
            {
                throw new ArgumentException("No Doctor with this id exists!");
            }
            if (workDayScheduleDTO.DayOfWeek < 0 || workDayScheduleDTO.DayOfWeek >= 7)
            {
                throw new ArgumentException("DayOfWeek should be between 0 and 6!");
            }
            var workDaySchedule = _mapper.Map<WorkDaySchedule>(workDayScheduleDTO);
            await _unitOfWork.WorkDaySchedulesRepository.InsertAsync(workDaySchedule);
            return workDayScheduleDTO;
        }

        public async Task<WorkDayScheduleDTO> Delete(WorkDayScheduleDTO workDayScheduleDTO)
        {
            var workDaySchedule = _mapper.Map<WorkDaySchedule>(workDayScheduleDTO);
            _unitOfWork.WorkDaySchedulesRepository.Delete(workDaySchedule);
            await _unitOfWork.SaveAsync();
            return workDayScheduleDTO;
        }

        public async Task<List<WorkDayScheduleDTO>> GetAll()
        {
            var workDaySchedules = await _unitOfWork.WorkDaySchedulesRepository.GetAllAsync();
            var workDayScheduleDTOs = _mapper.Map<IEnumerable<WorkDaySchedule>, List<WorkDayScheduleDTO>>(workDaySchedules);
            return workDayScheduleDTOs;
        }

        public async Task<WorkDayScheduleDTO> Update(long id, WorkDayScheduleDTO workDayScheduleDTO)
        {
            var workDaySchedule = _mapper.Map<WorkDaySchedule>(workDayScheduleDTO);
            _unitOfWork.WorkDaySchedulesRepository.Update(workDaySchedule);
            await _unitOfWork.SaveAsync();
            return workDayScheduleDTO;
        }

        public async Task<WorkDayScheduleDTO> GetById(long id)
        {
            var workDaySchedule = await _unitOfWork.WorkDaySchedulesRepository.GetByIdAsync(id);
            if (workDaySchedule == null)
            {
                throw new ArgumentException("There is no workDaySchedule with this id!");
            }
            var workDayScheduleDTO = _mapper.Map<WorkDayScheduleDTO>(workDaySchedule);
            return workDayScheduleDTO;
        }

        public async Task<List<WorkDayScheduleDTO>> GetWorkSchedule(long doctorId)
        {
            var workDaySchedules = await _unitOfWork.WorkDaySchedulesRepository.GetQueryable()
                .Where(x => x.DoctorId == doctorId)
                .OrderBy(x => x.DayOfWeek)
                .ToListAsync();

            var workDayScheduleDTOs = _mapper.Map<List<WorkDaySchedule>, List<WorkDayScheduleDTO>>(workDaySchedules);
            return workDayScheduleDTOs;
        }

        public async Task<WorkDayScheduleDTO> GetWorkDaySchedule(long doctorId, int day)
        {
            if (day < 0 || day >= 7)
            {
                throw new ArgumentException("Day should be between 0 and 6!");
            }
            var workDaySchedules = await _unitOfWork.WorkDaySchedulesRepository.GetQueryable()
                .Where(x => x.DoctorId == doctorId)
                .FirstOrDefaultAsync(x => x.DayOfWeek == day);

            var workDayScheduleDTO = _mapper.Map<WorkDayScheduleDTO>(workDaySchedules);
            return workDayScheduleDTO;
        }
    }
}
