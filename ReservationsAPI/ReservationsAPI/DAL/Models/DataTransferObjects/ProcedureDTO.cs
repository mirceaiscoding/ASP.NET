using System;
namespace ReservationsAPI.DAL.Models.DataTransferObjects
{
    public class ProcedureDTO
    {
        public long Id { get; set; }
        public string ProcedureName { get; set; }
        public int Cost { get; set; }

    }
}
