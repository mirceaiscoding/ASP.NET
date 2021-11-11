using System;
using System.Collections.Generic;
using AutoMapper;
using ReservationsAPI.DAL.Entities;
using ReservationsAPI.DAL.Models.DataTransferObjects;

namespace ReservationsAPI
{
    public class AutoMapping : Profile
    {
        public static Dictionary<Type, Type> mappings = new Dictionary<Type, Type>()
        {
            { typeof(Appointment), typeof(AppointmentDTO) },
            { typeof(Doctor), typeof(DoctorDTO) },
            { typeof(Pacient), typeof(PacientDTO) },
            { typeof(Procedure), typeof(ProcedureDTO) },
            { typeof(VacationDay), typeof(VacationDayDTO) },
            { typeof(WorkDaySchedule), typeof(WorkDayScheduleDTO) }
        };

        public AutoMapping()
        {
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<Pacient, PacientDTO>();
            CreateMap<Procedure, ProcedureDTO>();
            CreateMap<VacationDay, VacationDayDTO>();
            CreateMap<WorkDaySchedule, WorkDayScheduleDTO>();
        }
    }
}
