using System;
namespace ReservationsAPI.DAL.Models
{
    public class WorkDaySchedulePostModel
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public int DayOfWeek { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string BreakStartHour { get; set; }
        public string BreakEndHour { get; set; }
    }
}
