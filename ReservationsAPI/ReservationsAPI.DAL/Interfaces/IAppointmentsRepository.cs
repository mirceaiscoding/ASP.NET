﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models;

namespace ReservationsAPI.DAL.Interfaces
{
    public interface IAppointmentsRepository : IGenericRepository<Appointment>
    {
        Task<List<PacientAppointmentsModel>> GetPacientAppointments(long pacientId);
        Task<List<DoctorAppointmentsModel>> GetDoctorAppointments(long doctorId);
        Task<List<AppointmentsInformationModel>> GetAppointmentsInformation();
        Task<List<AppointmentsInformationModel>> GetUpcomingAppointmentsInformation();
        Task<List<AppointmentsInformationModel>> GetPreviousAppointmentsInformation();
        Task<AppointmentsInformationModel> GetAppointmentInformation(long pacientId, long doctorId, long procedureId, DateTime startTime);

        Appointment GetByCompositeKeyAsync(object[] id);
    }
}
