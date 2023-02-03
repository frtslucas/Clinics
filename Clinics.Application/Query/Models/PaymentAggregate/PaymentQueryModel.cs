using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PatientAggregate;

namespace Clinics.Application.Query.Models.PaymentAggregate
{
    public class PaymentQueryModel : BaseQueryModel, IQueryModel
    {
        public Guid PatientId { get; set; }
        public virtual PatientQueryModel? Patient { get; set; }

        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
