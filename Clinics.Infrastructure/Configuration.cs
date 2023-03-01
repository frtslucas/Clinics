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
        private const string _sqlConnectinString = "Server=(localdb)\\MSSQLLocalDB;Database=Clinics;Trusted_Connection=True;MultipleActiveResultSets=true";
        private const string _sqlConnectinStringReadOnly = $"{_sqlConnectinString};ApplicationIntent=ReadOnly";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<CommandDbContext>(options => options.UseSqlServer(_sqlConnectinString));
            services.AddDbContext<QueryDbContext>(options => options.UseSqlServer(_sqlConnectinStringReadOnly));
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddRepository<Patient, PatientId, IPatientRepository, PatientRepository>();
            services.AddRepository<Session, SessionId, ISessionRepository, SessionRepository>();
            services.AddRepository<Payment, PaymentId, IPaymentRepository, PaymentRepository>();

            services.AddQueryRepository<PatientQueryModel, IPatientQueryRepository, PatientQueryRepository>();
            services.AddQueryRepository<SessionQueryModel, ISessionQueryRepository, SessionQueryRepository>();
            services.AddQueryRepository<PaymentQueryModel, IPaymentQueryRepository, PaymentQueryRepository>();

            return services;
        }

        private static void AddRepository<TAggregateRoot, TIdentifier, TInterface, TClass>(this IServiceCollection services)
            where TAggregateRoot : class, IAggregateRoot<TIdentifier>
            where TIdentifier : IIdentifier, new()
            where TInterface : class, IRepository<TAggregateRoot, TIdentifier>
            where TClass : class, TInterface
        {
            services.AddScoped<TInterface, TClass>();
            services.AddScoped<IRepository<TAggregateRoot, TIdentifier>, TClass>();

            services.AddRepository<TAggregateRoot, TIdentifier, Guid, TInterface, TClass>();
        }

        private static void AddRepository<TAggregateRoot, TIdentifier, TIdType, TInterface, TClass>(this IServiceCollection services)
            where TAggregateRoot : class, IAggregateRoot<TIdentifier, TIdType>
            where TIdentifier : IIdentifier<TIdType>, new()
            where TInterface : class, IRepository<TAggregateRoot, TIdentifier, TIdType>
            where TClass : class, TInterface
        {
            services.AddScoped<TInterface, TClass>();
            services.AddScoped<IRepository<TAggregateRoot, TIdentifier, TIdType>, TClass>();
        }

        private static void AddQueryRepository<TQueryModel, TInterface, TClass>(this IServiceCollection services)
            where TQueryModel : class, IQueryModel
            where TInterface : class, IQueryRepository<TQueryModel>
            where TClass : class, TInterface
        {
            services.AddScoped<TInterface, TClass>();
            services.AddScoped<IQueryRepository<TQueryModel>, TClass>();

            services.AddQueryRepository<TQueryModel, Guid, TInterface, TClass>();
        }

        private static void AddQueryRepository<TQueryModel, TIdType, TInterface, TClass>(this IServiceCollection services)
            where TQueryModel : class, IQueryModel
            where TInterface : class, IQueryRepository<TQueryModel, TIdType>
            where TClass : class, TInterface
        {
            services.AddScoped<TInterface, TClass>();
            services.AddScoped<IQueryRepository<TQueryModel, TIdType>, TClass>();
        }
    }
}
