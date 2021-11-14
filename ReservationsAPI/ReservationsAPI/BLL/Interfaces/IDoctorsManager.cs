using System;
using System.Threading.Tasks;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IDoctorsManager
    {
        Task<bool> IsWorking(long doctorId, DateTime date);
    }
}
