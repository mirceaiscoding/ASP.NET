using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;

namespace ReservationsAPI.DAL.Repositories
{
    public class DoctorsRepository : GenericRepository<Doctor>, IDoctorsRepository
    {
        public DoctorsRepository(ReservationsContext context) : base(context) { }

        public async Task<bool> IsWorking(long doctorId, DateTime date)
        {
            var doctorWorkData =
                await entities
                .Include(x => x.VacationDays)
                .Include(x => x.WorkDaySchedules
                .Where(x => x.DayOfWeek == ((int)date.DayOfWeek)))
                .Where(x => x.Id == doctorId)
                .Where(x => x.VacationDays.AsQueryable().Where(y => y.Date == date) == null)
                .ToListAsync();

            if(doctorWorkData.Capacity == 0)
            {
                return false;
            } else
            {
                return true;
            }

        }
    }
}
