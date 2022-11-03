using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.AddPaymentToSession;
using Clinics.Application.Command.AddSessionToPatient;
using Clinics.Application.Command.InactivatePatient;
using Clinics.Application.Command.MarkSessionAsDone;
using Clinics.Application.Command.ReactivatePatient;
using Clinics.Application.Command.RegisterPatient;
using Clinics.Application.Command.SetAgreedValue;
using Clinics.Application.DTOs;
using Clinics.Application.Query.GetAll;
using Clinics.Application.Query.GetById;
using Clinics.Application.Query.GetSummaries;
using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Models.SessionAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Clinics.Application
{
    public static class Configuration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                options.AddProfile<MapperProfile>();
            });

            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();

            services.AddCommandHandler<AddPaymentToSessionCommand, AddPaymentToSessionCommandHandler>();
            services.AddCommandHandler<AddSessionToPatientCommand, AddSessionToPatientCommandHandler>();
            services.AddCommandHandler<InactivatePatientCommand, InactivatePatientCommandHandler>();
            services.AddCommandHandler<MarkSessionAsDoneCommand, MarkSessionAsDoneCommandHandler>();
            services.AddCommandHandler<ReactivatePatientCommand, ReactivatePatientCommandHandler>();
            services.AddCommandHandler<RegisterPatientCommand, RegisterPatientCommandHandler>();
            services.AddCommandHandler<SetAgreedValueCommand, SetAgreedValueCommandHandler>();

            services.AddQueryHandlers<PatientQueryModel, PatientDTO, PatientSummaryDTO>();
            services.AddQueryHandlers<SessionQueryModel, SessionDTO, SessionSummaryDTO>();

            return services;
        }

        private static void AddCommandHandler<TCommand, TCommandHandler>(this IServiceCollection services)
            where TCommand : ICommand
            where TCommandHandler : class, ICommandHandler<TCommand>
        {
            services.AddTransient<ICommandHandler<TCommand>, TCommandHandler>();
        }

        private static void AddQueryHandlers<TQueryModel, TDTO, TSummaryDTO>(this IServiceCollection services)
            where TQueryModel : class, IQueryModel
            where TDTO : class, IAggregateRootDTO
            where TSummaryDTO : class, ISummaryDTO
        {
            services.AddQueryHandler<GetByIdQuery<TDTO>, TDTO, GetByIdQueryHandler<TQueryModel, TDTO>>();
            services.AddQueryHandler<GetAllQuery<IEnumerable<TDTO>>, IEnumerable<TDTO>, GetAllQueryHandler<TQueryModel, TDTO>>();
            services.AddQueryHandler<GetSummariesQuery<IEnumerable<TSummaryDTO>>, IEnumerable<TSummaryDTO>, GetSummariesQueryHandler<TQueryModel, TSummaryDTO>>();
        }

        private static void AddQueryHandler<TQuery, TResult, TQueryHandler>(this IServiceCollection services)
            where TQuery : class, IQuery<TResult>
            where TQueryHandler : class, IQueryHandler<TQuery, TResult>
        {
            services.AddTransient<IQueryHandler<TQuery, TResult>, TQueryHandler>();
        }
    }
}
