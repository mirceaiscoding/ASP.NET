using System;
namespace ReservationsAPI.DAL.Entities
{
    public class VacationDay
    {
        public long Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
