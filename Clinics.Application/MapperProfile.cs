using AutoMapper;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Models.PaymentAggregate;
using Clinics.Application.Query.Models.SessionAggregate;

namespace Clinics.Application
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PatientQueryModel, PatientDTO>().ReverseMap();
            CreateMap<SessionQueryModel, SessionDTO>().ReverseMap();
            CreateMap<SessionPaymentQueryModel, SessionPaymentDTO>().ReverseMap();
            CreateMap<PaymentQueryModel, PaymentDTO>().ReverseMap();

            CreateProjection<PatientQueryModel, PatientSummaryDTO>()
                .ForMember(a => a.Initials, opts => opts.MapFrom(b => b.Name.GetInitials()));

            CreateProjection<PatientQueryModel, PatientMonthlySummaryDTO>()
                .ForMember(a => a.Initials, opts => opts.MapFrom(b => b.Name.GetInitials()))
                .ForMember(a => a.ActualMonthSessions, opts => opts.MapFrom(b =>
                    (byte)b.Sessions.Count(s => s.Done)));

            CreateProjection<SessionQueryModel, SessionSummaryDTO>()
                .ForMember(a => a.PatientInitials, opts => opts.MapFrom(b => b.Patient != null ? b.Patient.Name.GetInitials() : string.Empty))
                .ForMember(a => a.PaidValue, opts => opts.MapFrom(b => b.Payments.Sum(c => c.Value)));
        }
    }
}
