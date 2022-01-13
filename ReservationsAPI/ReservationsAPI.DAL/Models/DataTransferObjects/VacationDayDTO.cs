using System;
namespace ReservationsAPI.DAL.Models.DataTransferObjects
{
    public class VacationDayDTO
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}
