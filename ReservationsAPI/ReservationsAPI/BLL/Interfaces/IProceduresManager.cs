using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IProceduresManager
    {
        Task<List<ProcedureDTO>> GetAll();
    }
}
