using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IPacientsRepository : IGenericRepository<Pacient>
    {
        Task<int> GetNumberOfFutureAppointments(long pacientId);
        Task<Pacient> getUserData(int userId);
    }
}
