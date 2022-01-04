﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI.BLL.Interfaces
{
    public interface IDoctorsManager
    {
        Task<bool> IsWorking(long doctorId, DateTime date);

        Task<DoctorDTO> Insert(DoctorDTO doctorDTO);

        Task<List<DoctorDTO>> GetAll();

        Task<List<DoctorPublicInformationDTO>> GetAllPublicInformation();

        Task<DoctorDTO> GetById(long id);

        Task<DoctorDTO> Delete(DoctorDTO doctorDTO);

    }
}
