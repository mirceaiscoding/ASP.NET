using System;
namespace ReservationsAPI.DAL.Entities
{
    public class PacientUser : User
    {
        public long PacientId { get; set; }

        public virtual Pacient Pacient { get; set; }
    }
}
