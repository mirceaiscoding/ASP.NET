using System;
using System.Collections.Generic;

namespace ReservationsAPI.DAL.Entities
{
    public class Procedure
    {
        public long Id { get; set; }
        public string ProcedureName { get; set; }
        public int Cost { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
