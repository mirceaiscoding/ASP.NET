using System;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.DAL
{
    public class ReservationsContext : DbContext
    {
        public ReservationsContext(DbContextOptions<ReservationsContext> options) : base(options)
        {
        }

        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkDaySchedule> WorkDaySchedules { get; set; }
        public DbSet<VacationDay> VacationDays { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Procedure> Procedures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<WorkDaySchedule>()
                .HasOne(wds => wds.Doctor)
                .WithMany(d => d.WorkDaySchedules);

            builder.Entity<VacationDay>()
                .HasOne(vd => vd.Doctor)
                .WithMany(d => d.VacationDays);

            builder.Entity<Appointment>()
                .HasKey(a => new { a.PacientId, a.DoctorId, a.ProcedureId, a.StartTime });

            builder.Entity<Appointment>()
                .HasOne<Doctor>(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            builder.Entity<Appointment>()
                .HasOne<Pacient>(a => a.Pacient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PacientId);

            builder.Entity<Appointment>()
                .HasOne<Procedure>(a => a.Procedure)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.ProcedureId);

            base.OnModelCreating(builder);
        }
    }
}
