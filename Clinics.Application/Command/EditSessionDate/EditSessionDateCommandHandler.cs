using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;

namespace Clinics.Application.Command.EditSessionDate
{
    internal sealed class EditSessionDateCommandHandler : ICommandHandler<EditSessionDateCommand>
    {
        private readonly ISessionRepository _sessionRepository;

        public EditSessionDateCommandHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<Result> HandleAsync(EditSessionDateCommand command)
        {
            var session = await _sessionRepository.FindByIdAsync(SessionId.FromGuid(command.SessionId));

            if (session is null)
                return Result.Fail(Error.NotFound);

            session.EditDate(command.NewDate);

            return Result.Success;
        }
    }
}
