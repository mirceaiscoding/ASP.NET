using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.DAL.Repositories
{
    public class AppointmentsRepository : GenericRepository<Appointment>, IAppointmentsRepository
    {
        public AppointmentsRepository(ReservationsContext context) : base(context) { }

        public async Task<Appointment> GetByCompositeKeyAsync(object[] id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<List<DoctorAppointmentsModel>> GetDoctorAppointments(long doctorId)
        {
            var pacientAppointmentsModels = await entities
                .Include(x => x.Doctor)
                .Include(x => x.Pacient)
                .Include(x => x.Procedure)
                .Where(x => x.DoctorId == doctorId)
                .Select(x => new DoctorAppointmentsModel
                {
                    ProcedureName = x.Procedure.ProcedureName,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    PacientName = x.Pacient.LastName + " " + x.Pacient.FirstName
                })
                .ToListAsync();
            return pacientAppointmentsModels;
        }

        public async Task<List<PacientAppointmentsModel>> GetPacientAppointments(long pacientId)
        {
            var pacientAppointmentsModels = await entities
                .Include(x => x.Doctor)
                .Include(x => x.Pacient)
                .Include(x => x.Procedure)
                .Where(x => x.PacientId == pacientId)
                .Select(x => new PacientAppointmentsModel
                {
                    ProcedureName = x.Procedure.ProcedureName,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    DoctorName = x.Doctor.LastName + " " + x.Doctor.FirstName
                })
                .ToListAsync();
            return pacientAppointmentsModels;
        }
    }
}
