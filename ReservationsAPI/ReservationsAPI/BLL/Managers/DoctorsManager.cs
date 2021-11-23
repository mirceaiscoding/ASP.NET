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
    public class DoctorsManager : IDoctorsManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorDTO> Insert(DoctorDTO doctorDTO)
        {
            var doctor = _mapper.Map<Doctor>(doctorDTO);
            await _unitOfWork.DoctorsRepository.InsertAsync(doctor);
            return doctorDTO;
        }

        public async Task<bool> IsWorking(long doctorId, DateTime date)
        {
            return await _unitOfWork.DoctorsRepository.IsWorking(doctorId, date);
        }

        public async Task<List<DoctorDTO>> GetAll()
        {
            var doctors = await _unitOfWork.DoctorsRepository.GetAllAsync();
            return _mapper.Map<List<Doctor>, List<DoctorDTO>>(doctors);
        }

        public async Task<DoctorDTO> GetById(long id)
        {
            var doctor = await _unitOfWork.DoctorsRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new ArgumentException("No Doctor with this id exists!");
            }
            return _mapper.Map<DoctorDTO>(doctor);
        }
    }
}
