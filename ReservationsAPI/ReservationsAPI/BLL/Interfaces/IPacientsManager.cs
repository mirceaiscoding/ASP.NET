using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IPacientsManager
    {
        Task<int> GetNumberOfFutureAppointments(long pacientId);
    }
}
