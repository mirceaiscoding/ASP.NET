using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Managers
{
    public class AppointmentsManager : IAppointmentsManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AppointmentDTO>> GetAll()
        {
            var appointments = _unitOfWork.AppointmentsRepository.GetAll();
            var appointmentDTOs = _mapper.Map<IEnumerable<Appointment>, List<AppointmentDTO>>(appointments);
            return appointmentDTOs;
        }

        public Task<List<DoctorAppointmentsModel>> GetDoctorAppointments(long doctorId)
        {
            return _unitOfWork.AppointmentsRepository.GetDoctorAppointments(doctorId);
        }

        public Task<List<PacientAppointmentsModel>> GetPacientAppointments(long pacientId)
        {
            return _unitOfWork.AppointmentsRepository.GetPacientAppointments(pacientId);
        }
    }
}
