using System;
namespace ReservationsAPI.DAL.Models.DataTransferObjects
{
    public class AppointmentDTO
    {
        public long PacientId { get; set; }
        public long DoctorId { get; set; }
        public long ProcedureId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
