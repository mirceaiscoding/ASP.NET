using System;
using System.Collections.Generic;

namespace ReservationsAPI.Models
{
    public class Procedure
    {
        public long Id { get; set; }
        public string ProcedureName { get; set; }
        public int Cost { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
