using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.DAL.Entities;

namespace ReservationsAPI.DAL
{
    public class ReservationsContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public ReservationsContext(DbContextOptions<ReservationsContext> options) : base(options)
        {
        }

        // Not necessary?
        //public DbSet<PacientUser> PacientUsers { get; set; }
        //public DbSet<DoctorUser> DoctorUsers { get; set; }

        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkDaySchedule> WorkDaySchedules { get; set; }
        public DbSet<VacationDay> VacationDays { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Procedure> Procedures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<PacientUser>().ToTable("PacientUsers");
            builder.Entity<DoctorUser>().ToTable("DoctorUsers");

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
