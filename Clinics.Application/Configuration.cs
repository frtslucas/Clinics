﻿using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.AddPaymentToSession;
using Clinics.Application.Command.AddSessionToPatient;
using Clinics.Application.Command.InactivatePatient;
using Clinics.Application.Command.MarkSessionAsDone;
using Clinics.Application.Command.ProcessPatientPayment;
using Clinics.Application.Command.ReactivatePatient;
using Clinics.Application.Command.RegisterPatient;
using Clinics.Application.Command.SetAgreedValue;
using Clinics.Application.DTOs;
using Clinics.Application.Query.GetAll;
using Clinics.Application.Query.GetById;
using Clinics.Application.Query.GetPatientSummaries;
using Clinics.Application.Query.GetSessionSummaries;
using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Models.PaymentAggregate;
using Clinics.Application.Query.Models.SessionAggregate;
using Clinics.Domain.DomainServices;
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

            services.AddTransient<IPaymentProcessor, PaymentProcessor>();

            services.AddCommandHandler<AddPaymentToSessionCommand, AddPaymentToSessionCommandHandler>();
            services.AddCommandHandler<AddSessionToPatientCommand, AddSessionToPatientCommandHandler>();
            services.AddCommandHandler<InactivatePatientCommand, InactivatePatientCommandHandler>();
            services.AddCommandHandler<MarkSessionAsDoneCommand, MarkSessionAsDoneCommandHandler>();
            services.AddCommandHandler<ReactivatePatientCommand, ReactivatePatientCommandHandler>();
            services.AddCommandHandler<RegisterPatientCommand, RegisterPatientCommandHandler>();
            services.AddCommandHandler<SetAgreedValueCommand, SetAgreedValueCommandHandler>();
            services.AddCommandHandler<ProcessPatientPaymentCommand, ProcessPatientPaymentCommandHandler>();

            services.AddQueryHandlers<PatientQueryModel, PatientDTO>();
            services.AddQueryHandlers<SessionQueryModel, SessionDTO>();
            services.AddQueryHandlers<PaymentQueryModel, PaymentDTO>();
            services.AddQueryHandler<GetPatientSummariesQuery, IEnumerable<PatientSummaryDTO>, GetPatientSummariesQueryHandler>();
            services.AddQueryHandler<GetSessionSummariesQuery, IEnumerable<SessionSummaryDTO>, GetSessionSummariesQueryHandler>();

            return services;
        }

        private static void AddCommandHandler<TCommand, TCommandHandler>(this IServiceCollection services)
            where TCommand : ICommand
            where TCommandHandler : class, ICommandHandler<TCommand>
        {
            services.AddTransient<ICommandHandler<TCommand>, TCommandHandler>();
        }

        private static void AddQueryHandlers<TQueryModel, TDTO>(this IServiceCollection services)
            where TQueryModel : class, IQueryModel
            where TDTO : class, IAggregateRootDTO
        {
            services.AddQueryHandler<GetByIdQuery<TDTO>, TDTO, GetByIdQueryHandler<TQueryModel, TDTO>>();
            services.AddQueryHandler<GetAllQuery<IEnumerable<TDTO>>, IEnumerable<TDTO>, GetAllQueryHandler<TQueryModel, TDTO>>();
        }

        private static void AddQueryHandler<TQuery, TResult, TQueryHandler>(this IServiceCollection services)
            where TQuery : class, IQuery<TResult>
            where TQueryHandler : class, IQueryHandler<TQuery, TResult>
        {
            services.AddTransient<IQueryHandler<TQuery, TResult>, TQueryHandler>();
        }
    }
}
