using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IProceduresManager
    {
        Task<ProcedureDTO> Insert(ProcedureDTO procedureDTO);

        Task<ProcedureDTO> Update(long id, ProcedureDTO procedureDTO);

        Task<ProcedureDTO> UpdateCost(long id, int newCost);

        Task<List<ProcedureDTO>> GetAll();

        Task<ProcedureDTO> GetById(long id);

        Task<ProcedureDTO> Delete(ProcedureDTO procedureDTO);

        Task<bool> Delete(long id);
    }
}
