﻿using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Clinics.Domain.Shared;

namespace Clinics.Domain.Aggregates.SessionAggregate.Entities
{
    public class SessionPayment : Entity<SessionPaymentId>, IEntity<SessionPaymentId>
    {
        public Value Value { get; private set; }
        public DateTime Date { get; private set; }

        public SessionPayment(Value value, DateTime date)
        {
            Value = value;
            Date = date;
        }

        #region EF
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private SessionPayment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion
    }
}
