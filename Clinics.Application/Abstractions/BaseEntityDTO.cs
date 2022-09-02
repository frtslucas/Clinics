using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Abstractions
{
    public class BaseEntityDTO : BaseEntityDTO<Guid>, IEntityDTO
    {
    }

    public class BaseEntityDTO<TIdeType> : IEntityDTO<TIdeType>
    {
        public TIdeType Id { get; set; } = default!;
    }
}
