using System;
using System.Collections.Generic;

namespace ReservationsAPI.Models
{
    public class Pacient
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
