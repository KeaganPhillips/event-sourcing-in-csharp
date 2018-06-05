using Autofac;
using ES.Core.Aggregate;
using ES.Core.Command;
using ES.Core.Events;
using ES.Core.Logging;
using ES.CustomerService.AppLayer.Commands;
using ES.CustomerService.Domain;
using ES.CustomerService.Domain.ApplyEvent;
using ES.CustomerService.Domain.Events;
using ES.CustomerService.Domain.Factories;
using ES.CustomerService.Infrastructure.Logging;
using ES.CustomerService.Repository;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ES.CustomerService.API.Console
{
    internal static class Startup
    {
        public static IContainer SetupContainer()
        {
            IContainer container = null;
            var builder = new ContainerBuilder();
            
            builder.RegisterAssemblyTypes(
                    Assembly.GetExecutingAssembly(),        // Scan the current assembly
                    typeof(IEvent).Assembly,                // Scan the core assembly
                    typeof(Customer).Assembly,              // Scan the domain project
                    typeof(CreateCustomerCommand).Assembly, // Scan the App Layer
                    typeof(CustomerEventRepo).Assembly,     // Scan Repository project
                    typeof(DummyLogger).Assembly            // Scan the Infrastructrure project
                ).AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<DummyLogger>().As<ILogger>();
            builder.RegisterType<CommandDispatcher<Customer>>().As<ICommandDispatcher<Customer>>();
            builder.RegisterType<ICustomerFactory>().As<IAggregateFactory<Customer>>();
            builder.Register<IContainer>(x => container);

            builder.RegisterType<ApplyCustomerCreatedEvent_v1>().As<IApplyEvent<CustomerCreatedEvent, Customer>>();
            

            return container = builder.Build();
        }
    }
}
