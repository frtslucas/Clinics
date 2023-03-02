using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.EditSessionDate
{
    public record EditSessionDateCommand : ICommand
    {
        public Guid SessionId { get; set; }
        public DateTime NewDate { get; set; }
    }
}
