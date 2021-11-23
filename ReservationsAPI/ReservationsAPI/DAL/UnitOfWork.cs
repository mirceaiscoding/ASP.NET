using System;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Repositories;

namespace ReservationsAPI.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ReservationsContext _context;

        private AppointmentsRepository appointmentsRepository;
        private DoctorsRepository doctorsRepository;
        private PacientsRepository pacientsRepository;
        private ProceduresRepository proceduresRepository;
        private GenericRepository<WorkDaySchedule> workDaySchedulesRepository;
        private GenericRepository<VacationDay> vacationDaysRepository;

        public UnitOfWork(ReservationsContext context)
        {
            _context = context;
        }

        public IAppointmentsRepository AppointmentsRepository
        {
            get
            {

                if (this.appointmentsRepository == null)
                {
                    this.appointmentsRepository = new AppointmentsRepository(_context);
                }
                return appointmentsRepository;
            }
        }

        public IDoctorsRepository DoctorsRepository
        {
            get
            {

                if (this.doctorsRepository == null)
                {
                    this.doctorsRepository = new DoctorsRepository(_context);
                }
                return doctorsRepository;
            }
        }

        public IPacientsRepository PacientsRepository
        {
            get
            {

                if (this.pacientsRepository == null)
                {
                    this.pacientsRepository = new PacientsRepository(_context);
                }
                return pacientsRepository;
            }
        }

        public IProceduresRepository ProceduresRepository
        {
            get
            {

                if (this.proceduresRepository == null)
                {
                    this.proceduresRepository = new ProceduresRepository(_context);
                }
                return proceduresRepository;
            }
        }

        public IGenericRepository<WorkDaySchedule> WorkDaySchedulesRepository
        {
            get
            {

                if (this.workDaySchedulesRepository == null)
                {
                    this.workDaySchedulesRepository = new GenericRepository<WorkDaySchedule>(_context);
                }
                return workDaySchedulesRepository;
            }
        }

        public IGenericRepository<VacationDay> VacationDaysRepository
        {
            get
            {

                if (this.vacationDaysRepository == null)
                {
                    this.vacationDaysRepository = new GenericRepository<VacationDay>(_context);
                }
                return vacationDaysRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
