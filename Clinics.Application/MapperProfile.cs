using AutoMapper;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Models.PatientAggregate;

namespace Clinics.Application
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PatientQueryModel, PatientDTO>().ReverseMap();
            CreateMap<SessionQueryModel, SessionDTO>().ReverseMap();
            CreateMap<PaymentQueryModel, PaymentDTO>().ReverseMap();
        }
    }
}
