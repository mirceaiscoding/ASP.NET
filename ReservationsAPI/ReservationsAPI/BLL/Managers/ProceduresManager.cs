using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Managers
{
    public class ProceduresManager : IProceduresManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProceduresManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProcedureDTO> Insert(ProcedureDTO procedureDTO)
        {
            var procedure = _mapper.Map<Procedure>(procedureDTO);
            await _unitOfWork.ProceduresRepository.InsertAsync(procedure);
            return procedureDTO;
        }

        public async Task<ProcedureDTO> Update(long id, ProcedureDTO procedureDTO)
        {
            if (procedureDTO.Id != id)
            {
                throw new ArgumentException("Updated Procedure does not have the correct id!");
            }
            var procedure = _mapper.Map<Procedure>(procedureDTO);
            _unitOfWork.ProceduresRepository.Update(procedure);
            await _unitOfWork.SaveAsync();
            return procedureDTO;
        }

        public async Task<ProcedureDTO> UpdateCost(long id, int newCost)
        {
            _unitOfWork.ProceduresRepository.UpdateCost(id, newCost);
            return await GetById(id);
        }

        public async Task<List<ProcedureDTO>> GetAll()
        {
            var procedures = await _unitOfWork.ProceduresRepository.GetAllAsync();
            var procedureDTOs = _mapper.Map<IEnumerable<Procedure>, List<ProcedureDTO>>(procedures);
            return procedureDTOs;
        }

        public async Task<ProcedureDTO> GetById(long id)
        {
            var procedure = await _unitOfWork.ProceduresRepository.GetByIdAsync(id);
            if (procedure == null)
            {
                throw new ArgumentException("No Procedure with this id exists!");
            }
            return _mapper.Map<ProcedureDTO>(procedure);
        }

        public async Task<ProcedureDTO> Delete(ProcedureDTO procedureDTO)
        {
            var procedure = _mapper.Map<Procedure>(procedureDTO);
            _unitOfWork.ProceduresRepository.Delete(procedure);
            await _unitOfWork.SaveAsync();
            return procedureDTO;
        }
    }
}
