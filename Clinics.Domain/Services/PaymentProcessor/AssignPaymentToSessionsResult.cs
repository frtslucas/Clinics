using Clinics.Domain.Aggregates.SessionAggregate;

namespace Clinics.Domain.Services.PaymentProcessor
{
    public record AssignPaymentToSessionsResult
    {
        public IReadOnlyList<Session> SessionsUpdated { get; }
        public IReadOnlyList<Session> NewSessions { get; }

        public AssignPaymentToSessionsResult(IEnumerable<Session> sessionsUpdated, IEnumerable<Session> newSessions)
        {
            SessionsUpdated = sessionsUpdated.ToList();
            NewSessions = newSessions.ToList();
        }
    }
}
