using System;
namespace ReservationsAPI.DAL.Entities
{
    public class Appointment
    {
        public long PacientId { get; set; }
        public long DoctorId { get; set; }
        public long ProcedureId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Pacient Pacient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Procedure Procedure { get; set; }
    }
}
