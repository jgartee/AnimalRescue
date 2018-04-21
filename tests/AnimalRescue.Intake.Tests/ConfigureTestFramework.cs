using System.Reflection;
using Autofac;
using Xunit;
using Xunit.Sdk;
using Xunit.Abstractions;
using Xunit.Ioc.Autofac;

using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;

[assembly: TestFramework("AnimalRescue.Intake.Tests.ConfigureTestFramework", "AnimalRescue.Intake.Tests")]

namespace AnimalRescue.Intake.Tests
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        private const string TestSuffixConvention = "Tests";

        public ConfigureTestFramework(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t=> t.Name.EndsWith(TestSuffixConvention, System.StringComparison.CurrentCulture));

            builder.RegisterAssemblyTypes(typeof(Intake).Assembly)
                   .AsImplementedInterfaces();

            builder.Register(context => new TestOutputHelper())
                   .AsSelf()
                   .As<ITestOutputHelper>()
                   .InstancePerLifetimeScope();

            Container = builder.Build();

            var csl = new AutofacServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => csl);
        }


    }
}
