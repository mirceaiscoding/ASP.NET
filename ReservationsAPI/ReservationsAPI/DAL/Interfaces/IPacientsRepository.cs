using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IPacientsRepository : IGenericRepository<Pacient>
    {
        Task<int> GetNumberOfFutureAppointments(long pacientId);
    }
}
