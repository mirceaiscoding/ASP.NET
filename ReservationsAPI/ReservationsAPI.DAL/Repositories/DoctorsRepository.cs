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
                .Include(x => x.WorkDaySchedules.Where(x => x.DayOfWeek == ((int)date.DayOfWeek)))
                .FirstOrDefaultAsync(x => x.Id == doctorId);

            if(doctorWorkData.VacationDays.Where(x => x.Date == date).Count() == 0 // Is not on vacation
                && doctorWorkData.WorkDaySchedules.Count != 0) // Has a schedule for this weekday
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
