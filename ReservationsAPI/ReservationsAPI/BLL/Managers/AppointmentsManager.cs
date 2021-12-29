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

        public async Task<AppointmentsInformationModel> Insert(AppointmentDTO appointmentDTO)
        {
            if (await _unitOfWork.DoctorsRepository.GetByIdAsync(appointmentDTO.DoctorId) == null)
            {
                throw new ArgumentException("No Doctor with this id exists!");
            }
            if (await _unitOfWork.ProceduresRepository.GetByIdAsync(appointmentDTO.ProcedureId) == null)
            {
                throw new ArgumentException("No Procedure with this id exists!");
            }
            if (await _unitOfWork.PacientsRepository.GetByIdAsync(appointmentDTO.PacientId) == null)
            {
                throw new ArgumentException("No Pacient with this id exists!");
            }
            var appointment = _mapper.Map<Appointment>(appointmentDTO);
            await _unitOfWork.AppointmentsRepository.InsertAsync(appointment);
            return new AppointmentsInformationModel
            {
                doctorDTO = _mapper.Map<DoctorDTO>(appointment.Doctor),
                pacientDTO = _mapper.Map<PacientDTO>(appointment.Pacient),
                procedureDTO = _mapper.Map<ProcedureDTO>(appointment.Procedure),
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime
            };
        }

        public async Task<AppointmentDTO> Delete(AppointmentDTO appointmentDTO)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDTO);
            _unitOfWork.AppointmentsRepository.Delete(appointment);
            await _unitOfWork.SaveAsync();
            return appointmentDTO;
        }

        public Task<List<AppointmentsInformationModel>> GetAll()
        {
            return _unitOfWork.AppointmentsRepository.GetAppointmentsInformation();
        }

        public Task<AppointmentsInformationModel> GetAppointmentInformationById(long pacientId, long doctorId, long procedureId, DateTime startTime)
        {
            return _unitOfWork.AppointmentsRepository.GetAppointmentInformation(pacientId, doctorId, procedureId, startTime);
        }

        public Task<List<DoctorAppointmentsModel>> GetDoctorAppointments(long doctorId)
        {
            return _unitOfWork.AppointmentsRepository.GetDoctorAppointments(doctorId);
        }

        public Task<List<PacientAppointmentsModel>> GetPacientAppointments(long pacientId)
        {
            return _unitOfWork.AppointmentsRepository.GetPacientAppointments(pacientId);
        }

        public async Task<AppointmentDTO> UpdateTime(long pacientId, long doctorId, long procedureId, DateTime startTime, DateTime newStartTime)
        {
            var currentAppointmentDTO = await GetById(pacientId, doctorId, procedureId, startTime);
            var updatedAppointmentDTO = createNewAppointmentDTO(currentAppointmentDTO, newStartTime);
            await _unitOfWork.SaveAsync();

            var currentAppointment = _mapper.Map<Appointment>(currentAppointmentDTO);
            var updatedAppointment = _mapper.Map<Appointment>(updatedAppointmentDTO);

            _unitOfWork.AppointmentsRepository.Delete(currentAppointment);
            _unitOfWork.AppointmentsRepository.Insert(updatedAppointment);
            await _unitOfWork.SaveAsync();

            return updatedAppointmentDTO;
        }

        public async Task<AppointmentDTO> GetById(long pacientId, long doctorId, long procedureId, DateTime startTime)
        {
            Object[] compositeKey = { pacientId, doctorId, procedureId, startTime };
            var appointment = _unitOfWork.AppointmentsRepository.GetByCompositeKeyAsync(compositeKey);
            if (appointment == null)
            {
                throw new ArgumentException("There is no appointment with this id!");
            }
            var appointmentDTO = _mapper.Map<AppointmentDTO>(appointment);
            await _unitOfWork.SaveAsync();
            return appointmentDTO;
        }

        private AppointmentDTO createNewAppointmentDTO(AppointmentDTO appointmentDTO, DateTime newStartTime)
        {
            return new AppointmentDTO
            {
                PacientId = appointmentDTO.PacientId,
                DoctorId = appointmentDTO.DoctorId,
                ProcedureId = appointmentDTO.ProcedureId,
                StartTime = newStartTime,
                EndTime = newStartTime + (appointmentDTO.EndTime - appointmentDTO.StartTime)
            };
        }

    }
}
