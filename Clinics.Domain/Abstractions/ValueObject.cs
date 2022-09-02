using Clinics.Domain.Abstractions.Interfaces;

namespace Clinics.Domain.Abstractions
{
    public abstract record ValueObject : IValueObject
    {
    }

    public abstract class ValueObjectClass : IValueObject
    { 
    }
}
