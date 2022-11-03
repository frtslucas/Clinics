using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PatientAggregate;

namespace Clinics.Application.Query.Models.SessionAggregate
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
        public decimal ToPay { get => Value - Payments.Sum(p => p.Value); }

        public virtual IList<PaymentQueryModel> Payments { get; set; } = null!;
    }
}
