using System;
namespace ReservationsAPI.DAL.Models.DataTransferObjects
{
    public class DoctorDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string JobDescription { get; set; }

        public int UserId { get; set; }
    }
}
