using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IPacientsManager
    {
        Task<int> GetNumberOfFutureAppointments(long pacientId);

        Task<PacientDTO> Insert(PacientDTO pacientDTO);

        Task<PacientDTO> Update(long pacientId, PacientDTO pacientDTO);

    }
}
