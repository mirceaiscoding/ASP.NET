using System;
namespace ReservationsAPI.DAL.Entities
{
    public class WorkDaySchedule
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public DateTime BreakStartHour { get; set; }
        public DateTime BreakEndHour { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}