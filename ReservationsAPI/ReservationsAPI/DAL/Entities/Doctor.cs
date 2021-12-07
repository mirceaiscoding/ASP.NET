using System;
using System.Collections.Generic;

namespace ReservationsAPI.DAL.Entities
{
    public class Doctor : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DoctorPhoneNumber { get; set; }
        public string JobDescription { get; set; }

        public virtual ICollection<WorkDaySchedule> WorkDaySchedules { get; set; }
        public virtual ICollection<VacationDay> VacationDays { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
