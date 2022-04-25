using MediatR;
using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ophelia.UseCases.CustomerCases
{
    public class CreateCustomerInteractor : AsyncRequestHandler<CreateCustomerInputPort>
    {

        readonly ICustomerRepository CustomerRepository;
        readonly IUnitOfWork UnitOfWork;

        public CreateCustomerInteractor(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork) =>
            (CustomerRepository, UnitOfWork) =
            (customerRepository, unitOfWork);

        protected async override Task Handle(CreateCustomerInputPort request, CancellationToken cancellationToken)
        {
            Customer customer = new Customer()
            {
                Id = request.RequestData.Id,
                Name = request.RequestData.Name,
                BirthDate = request.RequestData.BirthDate
            };

            IEnumerable<Customer> customers =  CustomerRepository.GetCustomersBySpecification(new CustomerByIdSpecification(customer.Id));
            if(customers.Any())
                throw new GeneralException("Error al crear el cliente.", "Ya existe un cliente con esa identificación.");

            CustomerRepository.Create(customer);

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear el cliente.", ex.Message);
            }

            request.OutputPort.Handle(true);
        }

    }
}
