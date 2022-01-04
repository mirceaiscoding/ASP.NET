using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Repositories
{
    public class PacientsRepository : GenericRepository<Pacient>, IPacientsRepository
    {
        public PacientsRepository(ReservationsContext context) : base(context) { }

        public async Task<int> GetNumberOfFutureAppointments(long pacientId)
        {
            var pacient = await entities
                .Include(x => x.Appointments.Where(a => a.StartTime > DateTime.Now))
                .FirstOrDefaultAsync(x => x.Id == pacientId);
            var numberOfAppointments = pacient.Appointments.Count();
            return numberOfAppointments;
        }

        public async Task<Pacient> getUserData(int userId)
        {
            return await entities.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
