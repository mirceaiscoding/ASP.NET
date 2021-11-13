using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IAppointmentsManager
    {
        Task<List<DoctorAppointmentsModel>> GetDoctorAppointments(long doctorId);

        Task<List<PacientAppointmentsModel>> GetPacientAppointments(long pacientId);
    }
}
