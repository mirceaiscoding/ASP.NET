using System;
namespace ReservationsAPI.DAL.Models.DataTransferObjects
{
    public class PacientDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
