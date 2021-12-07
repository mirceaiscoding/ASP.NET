using System;
using System.Collections.Generic;

namespace ReservationsAPI.DAL.Entities
{
    public class Pacient : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PacientPhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
