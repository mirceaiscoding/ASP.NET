using System;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentsRepository AppointmentsRepository { get; }
        IDoctorsRepository DoctorsRepository { get; }
        IPacientsRepository PacientsRepository { get; }
        IGenericRepository<Procedure> ProceduresRepository { get; }
        IGenericRepository<WorkDaySchedule> WorkDaySchedulesRepository { get; }
        IGenericRepository<VacationDay> VacationDaysRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
