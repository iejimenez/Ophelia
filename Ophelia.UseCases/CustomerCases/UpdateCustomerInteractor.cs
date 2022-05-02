using FluentValidation;
using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using Ophelia.UseCases.Common.Validators;
using Ophelia.UseCasesDTOs.Customer.UpdateCustomer;
using Ophelia.UseCasesPorts.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.CustomerCases
{
    public class UpdateCustomerInteractor : IUpdateCustomerInputPort
    {
        readonly ICustomerRepository CustomerRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateCustomerOutputPort OutputPort;
        readonly IEnumerable<IValidator<UpdateCustomerParams>> Validators;

        public UpdateCustomerInteractor(ICustomerRepository customerRepository,
           IUnitOfWork unitOfWork, IUpdateCustomerOutputPort outputPort,
           IEnumerable<IValidator<UpdateCustomerParams>> validators) =>
           (CustomerRepository, UnitOfWork, OutputPort, Validators) =
           (customerRepository, unitOfWork, outputPort, validators);
        public async Task Handle(UpdateCustomerParams customer)
        {
            await Validator<UpdateCustomerParams>.Validate(customer, Validators);

           
            IEnumerable<Customer> customers = CustomerRepository.GetCustomersBySpecification(new CustomerByIdSpecification(customer.Id));
            if (!customers.Any())
                throw new GeneralException("Error al crear el cliente.", "No se encontro el cliente a modificar.");

            Customer customerdb = customers.FirstOrDefault();
            customerdb.Id = customer.Id;
            customerdb.Name = customer.Name;
            customerdb.BirthDate = customer.BirthDate;
           
            CustomerRepository.Update(customerdb);

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al actualizar el cliente.", ex.Message);
            }

            await OutputPort.Handle(true);
        }
    }
}
