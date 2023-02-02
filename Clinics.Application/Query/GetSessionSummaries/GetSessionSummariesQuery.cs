using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;

namespace Clinics.Application.Query.GetSessionSummaries
{
    public class GetSessionSummariesQuery : IQuery<IEnumerable<SessionSummaryDTO>>
    {
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
