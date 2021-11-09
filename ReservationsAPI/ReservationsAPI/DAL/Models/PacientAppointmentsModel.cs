using System;
namespace ReservationsAPI.DAL.Models
{
    public class PacientAppointmentsModel
    {
        public string DoctorName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ProcedureName { get; set; }
    }
}
