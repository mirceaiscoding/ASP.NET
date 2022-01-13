using System;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.DAL.Models
{
    public class PacientUserPostModel
    {
        public RegisterModel registerModel { get; set; }
        public PacientDTO PacientDTO { get; set; }
    }
}
