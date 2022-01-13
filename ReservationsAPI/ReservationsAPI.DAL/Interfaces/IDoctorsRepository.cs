using System;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IDoctorsRepository : IGenericRepository<Doctor>
    {
        Task<bool> IsWorking(long doctorId, DateTime date);
    }
}
