using System;
namespace ReservationsAPI.DAL.Models.DataTransferObjects
{
    public class WorkDayScheduleDTO
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public DateTime BreakStartHour { get; set; }
        public DateTime BreakEndHour { get; set; }
    }
}
