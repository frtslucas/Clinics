using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.Entities;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Clinics.Domain.Shared;

namespace Clinics.Application.Command.AddSessionToPatient
{
    internal sealed class AddSessionToPatientCommandHandler : ICommandHandler<AddSessionToPatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ISessionRepository _sessionRepository;

        public AddSessionToPatientCommandHandler(IPatientRepository patientRepository, ISessionRepository sessionRepository)
        {
            _patientRepository = patientRepository;
            _sessionRepository = sessionRepository;
        }

        public async Task<Result> HandleAsync(AddSessionToPatientCommand command)
        {
            var patient = await _patientRepository.FindByIdAsync(PatientId.FromGuid(command.PatientId));

            if (patient is null)
                return Result.Fail(Error.NotFound);

            var session = Session.Create(SessionId.FromGuid(command.Id), patient, command.Date, command.Observations);

            if (command.Done)
            {
                Payment? payment = null;

                if (command.PaymentValue.HasValue && command.PaymentDate.HasValue)
                {
                    var moneyValue = MoneyValue.FromDecimal(command.PaymentValue.Value);

                    payment = new Payment(moneyValue, command.PaymentDate.Value);
                }
                 
                session.MarkAsDone(payment);
            }

            await _sessionRepository.AddAsync(session);

            return Result.Success;
        }
    }
}
