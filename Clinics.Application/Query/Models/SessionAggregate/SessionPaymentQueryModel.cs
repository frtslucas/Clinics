using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Query.Models.SessionAggregate
{
    public class SessionPaymentQueryModel : BaseQueryModel, IQueryModel
    {
        public Guid SessionId { get; set; }
        public virtual SessionQueryModel? Session { get; set; }

        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
