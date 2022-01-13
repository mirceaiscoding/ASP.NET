using System;
namespace ReservationsAPI.DAL.Models.DataTransferObjects
{
    public class WorkDayScheduleDTO
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public TimeSpan BreakStartHour { get; set; }
        public TimeSpan BreakEndHour { get; set; }
    }
}
