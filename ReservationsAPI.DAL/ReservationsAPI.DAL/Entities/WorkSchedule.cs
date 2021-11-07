using System;
using System.Collections.Generic;

namespace ReservationsAPI.DAL.Entities
{
    public class WorkSchedule
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<WorkDaySchedule> WorkDaySchedules { get; set; }
    }
}
