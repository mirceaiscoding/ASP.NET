using System;
using System.Collections.Generic;

namespace ReservationsAPI.DAL.Entities
{
    public class Doctor
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string JobDescription { get; set; }

        public virtual WorkSchedule WorkSchedule { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
