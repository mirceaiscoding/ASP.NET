using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Models;

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
