using Clinics.Domain.Abstractions.Interfaces;

namespace Clinics.Domain.Abstractions
{
    public static class DomainEventsContext
    {
        private static readonly List<IDomainEvent> _events = new();
        public static IReadOnlyList<IDomainEvent> Events => _events.AsReadOnly();

        public static void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }

        public static void ClearEvents()
        {
            _events.Clear();
        }
    }
}
