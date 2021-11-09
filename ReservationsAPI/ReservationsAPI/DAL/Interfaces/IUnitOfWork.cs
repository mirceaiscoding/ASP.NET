using System;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Appointment> AppointmentsRepository { get; }
        IGenericRepository<Doctor> DoctorsRepository { get; }
        IGenericRepository<Pacient> PacientsRepository { get; }
        IGenericRepository<Procedure> ProceduresRepository { get; }
        IGenericRepository<WorkDaySchedule> WorkDaySchedulesRepository { get; }
    }
}
