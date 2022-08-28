﻿using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record MoneyValue : ValueObject, IValueObject
    {
        public decimal Value { get; }

        public MoneyValue(decimal value)
        {
            Guard.Against.Negative<InvalidMoneyValueException>(value);

            Value = value;
        }
    }
}