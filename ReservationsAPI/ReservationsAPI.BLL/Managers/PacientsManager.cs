using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Models;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Managers
{
    public class PacientsManager : IPacientsManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PacientsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> GetNumberOfFutureAppointments(long pacientId)
        {
            if (await _unitOfWork.PacientsRepository.GetByIdAsync(pacientId) == null)
            {
                throw new ArgumentException("No Pacient with this id exists!");
            }
            return await _unitOfWork.PacientsRepository.GetNumberOfFutureAppointments(pacientId);
        }

        public async Task<PacientDTO> Insert(PacientDTO pacientDTO)
        {
            var pacient = _mapper.Map<Pacient>(pacientDTO);
            await _unitOfWork.PacientsRepository.InsertAsync(pacient);
            return _mapper.Map<PacientDTO>(pacient);
        }

        public async Task<PacientDTO> Update(long pacientId, PacientDTO pacientDTO)
        {
            if (pacientDTO.Id != pacientId)
            {
                throw new ArgumentException("Updated Pacient does not have the correct id!");
            }
            var pacient = _mapper.Map<Pacient>(pacientDTO);
            _unitOfWork.PacientsRepository.Update(pacient);
            await _unitOfWork.SaveAsync();
            return pacientDTO;
        }

        public async Task<List<PacientDTO>> GetAll()
        {
            var pacients = await _unitOfWork.PacientsRepository.GetAllAsync();
            return _mapper.Map<List<Pacient>, List<PacientDTO>>(pacients);
        }

        public async Task<PacientDTO> GetById(long id)
        {
            var pacient = await _unitOfWork.PacientsRepository.GetByIdAsync(id);
            if (pacient == null)
            {
                throw new ArgumentException("No Pacient with this id exists!");
            }
            return _mapper.Map<PacientDTO>(pacient);
        }

        public async Task<PacientDTO> Delete(PacientDTO pacientDTO)
        {
            var pacient = _mapper.Map<Pacient>(pacientDTO);
            _unitOfWork.PacientsRepository.Delete(pacient);
            await _unitOfWork.SaveAsync();
            return pacientDTO;
        }

        public async Task<PacientDTO> GetUserData(int userId)
        {
            var pacient = await _unitOfWork.PacientsRepository.getUserData(userId);
            return _mapper.Map<PacientDTO>(pacient);
        }
    }
}
