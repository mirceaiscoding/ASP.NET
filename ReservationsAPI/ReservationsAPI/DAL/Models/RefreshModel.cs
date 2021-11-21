using System;
namespace ReservationsAPI.DAL.Models
{
    public class RefreshModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
