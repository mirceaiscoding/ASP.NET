using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IAppointmentsManager
    {
        Task<List<DoctorAppointmentsModel>> GetDoctorAppointments(long doctorId);

        Task<List<PacientAppointmentsModel>> GetPacientAppointments(long pacientId);

        Task<List<AppointmentsInformationModel>> GetAll();

        Task<AppointmentsInformationModel> GetAppointmentInformationById(long pacientId, long doctorId, long procedureId, DateTime startTime);

        Task<AppointmentDTO> GetById(long pacientId, long doctorId, long procedureId, DateTime startTime);

        Task<AppointmentsInformationModel> Insert(AppointmentDTO appointmentDTO);

        Task<AppointmentDTO> UpdateTime(long pacientId, long doctorId, long procedureId, DateTime startTime, DateTime newStartTime);

        Task<AppointmentDTO> Delete(AppointmentDTO appointmentDTO);
    }
}
