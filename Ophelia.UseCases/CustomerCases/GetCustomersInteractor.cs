using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using Ophelia.UseCasesDTOs.Customer.GetCustomer;
using Ophelia.UseCasesPorts.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.CustomerCases
{
    public class GetCustomersInteractor : IGetCustomerInputPort
    {
        readonly ICustomerRepository CustomerRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IGetCustomerOutputPort OutputPort;

        public GetCustomersInteractor(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork, IGetCustomerOutputPort outputPort) =>
            (CustomerRepository, UnitOfWork, OutputPort) =
            (customerRepository, unitOfWork, outputPort);

        public async Task Handle()
        {
            IEnumerable<GetCustomerResponse> customers = CustomerRepository.GetCustomersBySpecification(new CustomerAllSpecification())
                .Select(c=> new GetCustomerResponse() { 
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate
                });
            await OutputPort.Handle(customers.ToList());
        }
    }
}
