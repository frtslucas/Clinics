using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PaymentAggregate;
using Clinics.Application.Query.Models.SessionAggregate;

namespace Clinics.Application.Query.Models.PatientAggregate
{
    public class PatientQueryModel : BaseQueryModel, IQueryModel
    {
        public string Name { get; set; } = null!;
        public ushort Age 
        { 
            get 
            {
                var age = DateTime.Now.Year - BirthDate.Year;

                if (BirthDate.Month < DateTime.Now.Month || BirthDate.Day < DateTime.Now.Day)
                    age--;

                return (ushort)age;
            } 
        }

        public DateTime BirthDate { get; set; }
        public string Occupation { get; set; } = null!;
        public string PlaceOfBirth { get; set; } = null!;
        public decimal? AgreedValue { get; set; }
        public string? StreetAddress { get; set; }
        public int? StreetNumber { get; set; }
        public string? ExtraLine { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? RG { get; set; }
        public string? CPF { get; set; }
        public byte EstimatedMonthSessions { get; set; }
        public decimal TotalPaid { get => Sessions.Sum(a => a.TotalPaid); }
        public decimal TotalPending { get => Sessions.Sum(a => a.TotalPending); }
        public bool Active { get; set; }

        public virtual IList<SessionQueryModel> Sessions { get; set; } = null!;
        public virtual IList<PaymentQueryModel> Payments { get; set; } = null!;
    }
}
