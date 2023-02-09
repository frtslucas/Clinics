using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Models.PaymentAggregate;
using Clinics.Application.Query.Models.SessionAggregate;
using Clinics.Application.Query.Repository;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Clinics.Domain.Aggregates.PaymentAggregate.ValueObjects;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Clinics.Infrastructure.EntityFramework.Command;
using Clinics.Infrastructure.EntityFramework.Command.Repositories;
using Clinics.Infrastructure.EntityFramework.Query;
using Clinics.Infrastructure.EntityFramework.Query.QueryRepository;
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
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IRepository<Patient, PatientId>, PatientRepository>();
            services.AddScoped<IRepository<Session, SessionId>, SessionRepository>();
            services.AddScoped<IRepository<Payment, PaymentId>, PaymentRepository>();

            services.AddScoped<IPatientQueryRepository, PatientQueryRepository>();
            services.AddScoped<ISessionQueryRepository, SessionQueryRepository>();
            services.AddScoped<IPaymentQueryRepository, PaymentQueryRepository>();
            services.AddScoped<IQueryRepository<PatientQueryModel>, PatientQueryRepository>();
            services.AddScoped<IQueryRepository<SessionQueryModel>, SessionQueryRepository>();
            services.AddScoped<IQueryRepository<PaymentQueryModel>, PaymentQueryRepository>();

            return services;
        }
    }
}
