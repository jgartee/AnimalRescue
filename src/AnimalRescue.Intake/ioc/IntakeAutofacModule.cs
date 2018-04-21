using System;
using Microsoft.Extensions.Configuration;
using Autofac;

namespace AnimalRescue.Intake.Ioc
{
    public class IntakeAutofacModule : Module
    {
        public IConfigurationRoot Config { get; }

        public IntakeAutofacModule(IConfigurationRoot config)
        {
            Config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(Intake).Assembly)
                .AsImplementedInterfaces();
        }
    }
}
