using AutoMapper;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Models.SessionAggregate;

namespace Clinics.Application
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PatientQueryModel, PatientDTO>().ReverseMap();
            CreateMap<SessionQueryModel, SessionDTO>().ReverseMap();
            CreateMap<PaymentQueryModel, PaymentDTO>().ReverseMap();

            CreateProjection<PatientQueryModel, PatientSummaryDTO>()
                .ForMember(a => a.Initials, opts => opts.MapFrom(b => b.Name.GetInitials()))
                .ForMember(a => a.ActualMonthSessions, opts => opts.MapFrom(b =>
                    (byte)b.Sessions.Where(c => c.Date.Year == DateTime.UtcNow.Year && c.Date.Month == DateTime.UtcNow.Month).Count()));

            CreateProjection<SessionQueryModel, SessionSummaryDTO>()
                .ForMember(a => a.PatientInitials, opts => opts.MapFrom(b => b.Patient != null ? b.Patient.Name.GetInitials() : string.Empty))
                .ForMember(a => a.PaidValue, opts => opts.MapFrom(b => b.Payments.Sum(c => c.Value)));
        }
    }
}
