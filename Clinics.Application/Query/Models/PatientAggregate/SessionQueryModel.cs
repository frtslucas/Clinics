using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Query.Models.PatientAggregate
{
    public class SessionQueryModel : BaseQueryModel, IQueryModel
    {
        public Guid PatientId { get; set; }
        public virtual PatientQueryModel? Patient { get; set; }

        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string? Observations { get; set; }
        public bool Done { get; set; }
        public bool Paid { get; set; }

        public virtual IList<PaymentQueryModel>? Payments { get; set; }
    }
}
