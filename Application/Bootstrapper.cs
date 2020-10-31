using Application.Common.ApplicationServices.AlphanumericTokenGenerator;
using Application.Common.ApplicationServices.DateTime;
using Application.Common.ApplicationServices.EmailVerification;
using Application.Common.ApplicationServices.PasswordHashing;
using Application.Common.ApplicationServices.PasswordResetTokenSender;
using Application.Common.ApplicationServices.SecurePasswordSaltGenerator;
using Application.Common.Extensions.ValidatorRegistrationExtension;
using Application.Common.Mapper;
using Application.Common.PipelineBehaviour;
using ApplicationDependencies.EmailSender;
using Autofac;
using AutoMapper;
using Domain.Services;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MockEmailSender;
using System;
using System.Collections.Generic;
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

            builder.RegisterType<Mediator>().As<IMediator>().SingleInstance();
            builder.RegisterInstance(new Mapper(new MapperConfig().GetConfiguration())).As<IMapper>().SingleInstance();
            builder.RegisterValidators();
            builder.RegisterType(typeof(ValidationBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterType<MockEmailSender.MockEmailSender>().As<IEmailSender>().SingleInstance();

            #region Application Services
            builder.RegisterType<AlphanumericTokenGenerator>().As<IAlphanumericTokenGenerator>().SingleInstance();
            builder.RegisterType<DateTimeService>().As<IDateTimeService>().SingleInstance();
            builder.RegisterType<EmailVerificationService>().As<IEmailVerifierService>().SingleInstance();
            builder.RegisterType<PasswordHashingService>().As<IPasswordHashingService>().SingleInstance();
            builder.RegisterType<PasswordResetTokenSender>().As<IPasswordResetTokenSenderService>().SingleInstance();
            builder.RegisterType<SecurePasswordSaltGeneratorService>().As<ISecurePasswordSaltGeneratorService>();
            #endregion

            _container = builder.Build();
        }
    }
}
