using System;
namespace ReservationsAPI.DAL.Models
{
    public class NewStartTimeAppointmentModel
    {
        public long PacientId { get; set; }
        public long DoctorId { get; set; }
        public long ProcedureId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime NewStartTime { get; set; }
    }
}
