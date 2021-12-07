using System;
namespace ReservationsAPI.DAL.Entities
{
    public class DoctorUser : User
    {
        public long DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
