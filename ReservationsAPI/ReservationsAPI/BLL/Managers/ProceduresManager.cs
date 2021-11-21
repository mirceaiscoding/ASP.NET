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

        public async Task<List<ProcedureDTO>> GetAll()
        {
            var procedures = await _unitOfWork.ProceduresRepository.GetAllAsync();
            var procedureDTOs = _mapper.Map<IEnumerable<Procedure>, List<ProcedureDTO>>(procedures);
            return procedureDTOs;
        }
    }
}
