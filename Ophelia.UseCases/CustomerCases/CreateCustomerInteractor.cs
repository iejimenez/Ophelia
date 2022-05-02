
using FluentValidation;
using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using Ophelia.UseCases.Common.Validators;
using Ophelia.UseCasesDTOs.Product.CreateCustomer;
using Ophelia.UseCasesPorts.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ophelia.UseCases.CustomerCases
{
    public class CreateCustomerInteractor : ICreateCustomerInputPort
    {

        readonly ICustomerRepository CustomerRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateCustomerOutputPort OutputPort;
        readonly IEnumerable<IValidator<CreateCustomerParams>> Validators;

        public CreateCustomerInteractor(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork, ICreateCustomerOutputPort outputPort,
            IEnumerable<IValidator<CreateCustomerParams>> validators) =>
            (CustomerRepository, UnitOfWork, OutputPort, Validators) =
            (customerRepository, unitOfWork, outputPort, validators);

        public async Task Handle(CreateCustomerParams customer)
        {

            await Validator<CreateCustomerParams>.Validate(customer, Validators);

            Customer customerdb = new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                BirthDate = customer.BirthDate
            };

            IEnumerable<Customer> customers = CustomerRepository.GetCustomersBySpecification(new CustomerByIdSpecification(customer.Id));
            if (customers.Any())
                throw new GeneralException("Error al crear el cliente.", "Ya existe un cliente con esa identificación.");

            CustomerRepository.Create(customerdb);

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear el cliente.", ex.Message);
            }

            await OutputPort.Handle(customer.Id);
        }

    }
}
