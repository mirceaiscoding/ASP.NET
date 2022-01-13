using System;
namespace ReservationsAPI.DAL.Entities
{
    public class WorkDaySchedule
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public TimeSpan BreakStartHour { get; set; }
        public TimeSpan BreakEndHour { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}