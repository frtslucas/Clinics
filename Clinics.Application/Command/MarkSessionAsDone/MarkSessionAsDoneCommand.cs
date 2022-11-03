﻿using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.MarkSessionAsDone
{
    public record MarkSessionAsDoneCommand : ICommand
    {
        public Guid SessionId { get; set; }
        public decimal? PaymentValue { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
