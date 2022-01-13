using System;
namespace ReservationsAPI.BLL
{
    public class RefreshTokenResult
    {
        public bool Success { get; set; }
        public string NewAccessToken { get; set; }
    }
}
