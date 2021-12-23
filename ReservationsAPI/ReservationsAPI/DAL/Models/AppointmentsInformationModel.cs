using System;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Models
{
    public class AppointmentsInformationModel
    {
        public PacientDTO pacientDTO { get; set; }
        public DoctorDTO doctorDTO { get; set; }
        public ProcedureDTO procedureDTO { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
