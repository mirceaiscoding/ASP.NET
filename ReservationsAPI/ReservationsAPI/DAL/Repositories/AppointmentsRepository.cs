using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Repositories
{
    public class AppointmentsRepository : GenericRepository<Appointment>, IAppointmentsRepository
    {

        private readonly IMapper _mapper;

        public AppointmentsRepository(ReservationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public Appointment GetByCompositeKeyAsync(object[] id)
        {
            var appointment = entities.Find(id);
            _context.Entry(appointment).State = EntityState.Detached;
            return appointment;
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
                .OrderBy(x => x.StartTime)
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
                .OrderBy(x => x.StartTime)
                .ToListAsync();
            return pacientAppointmentsModels;
        }

        public async Task<List<AppointmentsInformationModel>> GetAppointmentsInformation()
        {
            var appointmentsInformationModels = await entities
                .Include(x => x.Doctor)
                .Include(x => x.Pacient)
                .Include(x => x.Procedure)
                .Select(x => new AppointmentsInformationModel
                {
                    doctorDTO = _mapper.Map<DoctorDTO>(x.Doctor),
                    pacientDTO = _mapper.Map<PacientDTO>(x.Pacient),
                    procedureDTO = _mapper.Map<ProcedureDTO>(x.Procedure),
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                })
                .OrderBy(x => x.StartTime)
                .ToListAsync();
            return appointmentsInformationModels;
        }
    }
}
