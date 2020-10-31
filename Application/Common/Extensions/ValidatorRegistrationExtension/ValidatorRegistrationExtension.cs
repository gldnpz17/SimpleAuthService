using Autofac;
using Autofac.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Application.Common.Extensions.ValidatorRegistrationExtension
{
    internal static class ValidatorRegistrationExtension
    {
        /// <summary>
        /// this would only function if you have 1 validator/type.
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterValidators(this ContainerBuilder builder)
        {
            //get all validators
            var validators = Assembly.GetAssembly(typeof(AbstractValidator<>)).GetTypes();

            //register all validators
            validators.ToList().ForEach(
                (v) =>
                {
                    //construct IValidator
                    var constructedType = typeof(IValidator<>).MakeGenericType(new Type[] { v });

                    //register validator
                    builder.RegisterType(v).As(constructedType);
                });
        }
    }
}
