using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;

namespace Clinics.Application.Command.MarkSessionAsDone
{
    internal sealed class MarkSessionAsDoneCommandHandler : ICommandHandler<MarkSessionAsDoneCommand>
    {
        private readonly ISessionRepository _sessionRepository;

        public MarkSessionAsDoneCommandHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<Result> HandleAsync(MarkSessionAsDoneCommand command)
        {
            var session = await _sessionRepository.FindByIdAsync(SessionId.FromGuid(command.SessionId));

            if (session is null)
                return Result.Fail(Error.NotFound);

            session.MarkAsDone();

            await _sessionRepository.UpdateAsync(session);

            return Result.Success;
        }
    }
}
