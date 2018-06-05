using Autofac;
using ES.Core.Command;
using ES.CustomerService.AppLayer.Commands;
using ES.CustomerService.Domain;
using System;

namespace ES.CustomerService.API.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // The following code will propably be behind a API controller or 
            // code woking a queue. The console app is just for demo 

            var container = Startup.SetupContainer();
            var dispatcher = container.Resolve<ICommandDispatcher<Customer>>();

            // Create 2 customers
            var cust1Id = _createCustomer(dispatcher);
            var cust2Id = _createCustomer(dispatcher);

            // Change customer 1's address
            _changeAddress(cust1Id, dispatcher);

            // Deactiveate Customer 2
            _deactiveCustomer(cust1Id, dispatcher);
        }

        private static void _deactiveCustomer(Guid cust1Id, ICommandDispatcher<Customer> dispatcher)
        {
            // Get the command from the API (AMQP/REST..)
            var commandId = Guid.NewGuid(); // CLIENT genrated command id. 
            var dateCreated = DateTime.Now; // Date/Time the client created the command
            var command = new DeactiveCustomerCommand(commandId, dateCreated, cust1Id);

            // Dispatch the command
            dispatcher.Dispatch(command);
        }

        private static Guid _createCustomer(ICommandDispatcher<Customer> dispatcher)
        {
            // Get the command from the API (AMQP/REST..)
            var commandId = Guid.NewGuid(); // CLIENT genrated command id. 
            var dateCreated = DateTime.Now; // Date/Time the client created the command
            var command = new CreateCustomerCommand(commandId, dateCreated)
            {
                Name = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                Address = Faker.Address.StreetAddress(),
                Status = CustomerStatus.Active               
            };

            // Dispatch the command
            dispatcher.Dispatch(command);

            return command.AggregateId;
        }

        private static void _changeAddress(Guid aggId, ICommandDispatcher<Customer> dispatcher)
        {
            // Get the command from the API (AMQP/REST..)
            var commandId = Guid.NewGuid(); // CLIENT genrated command id. 
            var dateCreated = DateTime.Now; // Date/Time the client created the command
            var command = new UpdateAddressCommand(commandId, dateCreated, aggId)
            {
                NewAddressDetails = Faker.Address.StreetAddress()
            };

            // Dispatch the command
            dispatcher.Dispatch(command);
        }
    }
}
