using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.BLL.Managers
{
    public class PacientsManager : IPacientsManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public PacientsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<PacientAppointmentsModel>> GetAppointments(long pacientId)
        {
            var pacientAppointmentsModels = await _unitOfWork
                .AppointmentsRepository
                .GetQueryable()
                .Include(x => x.Doctor)
                .Include(x => x.Pacient)
                .Include(x => x.Procedure)
                .Where(x => x.PacientId == pacientId)
                .Select(x => new PacientAppointmentsModel {
                    ProcedureName = x.Procedure.ProcedureName,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    DoctorName = x.Doctor.LastName + " " + x.Doctor.FirstName })
                .ToListAsync();
            return pacientAppointmentsModels;
        }
    }
}
