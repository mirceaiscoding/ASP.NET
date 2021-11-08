using System;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Repositories;

namespace ReservationsAPI.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ReservationsContext _context;

        private GenericRepository<Appointment> appointmentsRepository;
        private GenericRepository<Doctor> doctorsRepository;
        private GenericRepository<Pacient> pacientsRepository;
        private GenericRepository<Procedure> proceduresRepository;
        private GenericRepository<WorkDaySchedule> workDaySchedulesRepository;
        private GenericRepository<WorkSchedule> workSchedulesRepository;

        public UnitOfWork(ReservationsContext context)
        {
            _context = context;
        }

        public IGenericRepository<Appointment> AppointmentsRepository
        {
            get
            {

                if (this.appointmentsRepository == null)
                {
                    this.appointmentsRepository = new GenericRepository<Appointment>(_context);
                }
                return appointmentsRepository;
            }
        }

        public IGenericRepository<Doctor> DoctorsRepository
        {
            get
            {

                if (this.doctorsRepository == null)
                {
                    this.doctorsRepository = new GenericRepository<Doctor>(_context);
                }
                return doctorsRepository;
            }
        }

        public IGenericRepository<Pacient> PacientsRepository
        {
            get
            {

                if (this.pacientsRepository == null)
                {
                    this.pacientsRepository = new GenericRepository<Pacient>(_context);
                }
                return pacientsRepository;
            }
        }

        public IGenericRepository<Procedure> ProceduresRepository
        {
            get
            {

                if (this.proceduresRepository == null)
                {
                    this.proceduresRepository = new GenericRepository<Procedure>(_context);
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

        public IGenericRepository<WorkSchedule> WorkSchedulesRepository
        {
            get
            {

                if (this.workSchedulesRepository == null)
                {
                    this.workSchedulesRepository = new GenericRepository<WorkSchedule>(_context);
                }
                return workSchedulesRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
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
