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
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Doctor, DoctorPublicInformationDTO>().ReverseMap();
            CreateMap<Pacient, PacientDTO>().ReverseMap();
            CreateMap<Procedure, ProcedureDTO>().ReverseMap();
            CreateMap<VacationDay, VacationDayDTO>().ReverseMap();
            CreateMap<WorkDaySchedule, WorkDayScheduleDTO>().ReverseMap();
        }
    }
}
