using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Query.Models.PatientAggregate
{
    public class PatientQueryModel : BaseQueryModel, IQueryModel
    {
        public string Name { get; set; } = null!;
        public ushort Age 
        { 
            get 
            {
                var age = DateTime.Now.Year - BirthDate.Year;

                if (BirthDate.Month < DateTime.Now.Month || BirthDate.Day < DateTime.Now.Day)
                    age--;

                return (ushort)age;
            } 
        }

        public DateTime BirthDate { get; set; }
        public string Occupation { get; set; } = null!;
        public string CountryOfBirth { get; set; } = null!;
        public decimal? AgreedValue { get; set; }
        public string? StreetAddress { get; set; }
        public int? StreetNumber { get; set; }
        public string? ExtraLine { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? RG { get; set; }
        public string? CPF { get; set; }
        public bool Active { get; set; }

        public virtual IList<SessionQueryModel> Sessions { get; set; } = null!;
    }
}
