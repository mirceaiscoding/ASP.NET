using System;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Models
{
    public class DoctorUserPostModel
    {
        public RegisterModel registerModel { get; set; }
        public DoctorDTO doctorDTO { get; set; }
    }
}
