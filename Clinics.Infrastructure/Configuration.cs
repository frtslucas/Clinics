using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Models.SessionAggregate;
using Clinics.Application.Query.Providers;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Clinics.Infrastructure.EntityFramework.Command;
using Clinics.Infrastructure.EntityFramework.Command.Repositories;
using Clinics.Infrastructure.EntityFramework.Query;
using Clinics.Infrastructure.EntityFramework.Query.QueryProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clinics.Infrastructure
{
    public static class Configuration
    {
        private const string sqlConnectinString = "Server=(localdb)\\MSSQLLocalDB;Database=Clinics;Trusted_Connection=True;MultipleActiveResultSets=true";
        private const string sqlConnectinStringReadOnly = $"{sqlConnectinString};ApplicationIntent=ReadOnly";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<CommandDbContext>(options => options.UseSqlServer(sqlConnectinString));
            services.AddDbContext<QueryDbContext>(options => options.UseSqlServer(sqlConnectinStringReadOnly));
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IRepository<Patient, PatientId>, PatientRepository>();
            services.AddScoped<IRepository<Session, SessionId>, SessionRepository>();

            services.AddScoped<IPatientQueryProvider, PatientQueryProvider>();
            services.AddScoped<ISessionQueryProvider, SessionQueryProvider>();
            services.AddScoped<IQueryProvider<PatientQueryModel>, PatientQueryProvider>();
            services.AddScoped<IQueryProvider<SessionQueryModel>, SessionQueryProvider>();

            return services;
        }
    }
}
