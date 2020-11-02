using Application.Accounts.Commands.CreateAccount;
using Application.Common.ApplicationServices.AlphanumericTokenGenerator;
using Application.Common.ApplicationServices.DateTime;
using Application.Common.ApplicationServices.EmailVerification;
using Application.Common.ApplicationServices.PasswordHashing;
using Application.Common.ApplicationServices.PasswordResetTokenSender;
using Application.Common.ApplicationServices.SecurePasswordSaltGenerator;
using Application.Common.Configuration;
using Application.Common.Mapper;
using Application.Common.PipelineBehaviour;
using ApplicationDependencies.EmailSender;
using ApplicationDependencies.UnitOfWork;
using Autofac;
using AutoMapper;
using Domain.Services;
using EFCorePostgresPersistence.UnitOfWork;
using FluentValidation;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MockEmailSender;
using SMTPEmailSender;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public class Bootstrapper
    {
        public IMediator Mediator { get; }

        private IContainer _container;

        public Bootstrapper()
        {
            RegisterDependencies();

            Mediator = _container.Resolve<IMediator>();
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterMediatR(Assembly.GetExecutingAssembly());
            
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.IsAssignableFrom(typeof(IRequestHandler<>)))
                .AsSelf();
            
            builder.RegisterInstance(new Mapper(new MapperConfig().GetConfiguration())).As<IMapper>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.IsClosedTypeOf(typeof(AbstractValidator<>)))
                .AsClosedTypesOf(typeof(IValidator<>));

            builder.RegisterGeneric(typeof(ValidationBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

            builder.RegisterInstance(
                new SmtpEmailSender(
                    Environment.GetEnvironmentVariable("EMAIL_CREDENTIAL_ADDRESS"),
                    Environment.GetEnvironmentVariable("EMAIL_CREDENTIAL_PASSWORD"),
                    "SimpleAuthService")).As<IEmailSender>().SingleInstance();

            //builder.RegisterType<MockEmailSender.MockEmailSender>().As<IEmailSender>().SingleInstance();
            
            builder.RegisterType<EFCorePostgresPersistence.UnitOfWork.UnitOfWork>().As<IUnitOfWork>().SingleInstance();

            builder.RegisterInstance(
                new ApplicationConfiguration()
                {
                    MaxUsernameLength = 64,
                    MinPasswordLength = 8,
                    MaxPasswordLength = 128
                });

            #region Application Services
            builder.RegisterType<AlphanumericTokenGenerator>().As<IAlphanumericTokenGenerator>().SingleInstance();
            
            builder.RegisterType<DateTimeService>().As<IDateTimeService>().SingleInstance();
            
            builder.RegisterType<EmailVerificationService>().As<IEmailVerifierService>().SingleInstance();
            
            builder.RegisterType<PasswordHashingService>().As<IPasswordHashingService>().SingleInstance();
            
            builder.RegisterType<PasswordResetTokenSender>().As<IPasswordResetTokenSenderService>().SingleInstance();
            
            builder.RegisterType<SecurePasswordSaltGeneratorService>().As<ISecureRandomStringGeneratorService>();
            #endregion

            _container = builder.Build();
        }
    }
}
