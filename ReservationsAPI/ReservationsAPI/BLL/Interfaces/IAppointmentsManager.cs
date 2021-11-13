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

        Task<List<AppointmentDTO>> GetAll();
    }
}
