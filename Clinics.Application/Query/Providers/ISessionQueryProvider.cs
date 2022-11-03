using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.SessionAggregate;

namespace Clinics.Application.Query.Providers
{
    public interface ISessionQueryProvider : IQueryProvider<SessionQueryModel>
    {
    }
}
