using FluentValidation;
using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using Ophelia.UseCases.Common.Validators;
using Ophelia.UseCasesDTOs;
using Ophelia.UseCasesPorts.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.CustomerCases
{
    
    public class DeleteCustomerInteractor : IDeleteCustomerInputPort
    {
        readonly ICustomerRepository CustomerRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IDeleteCustomerOutputPort OutputPort;
        readonly IEnumerable<IValidator<DeleteCustomerParams>> Validators;

        public DeleteCustomerInteractor(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork, IDeleteCustomerOutputPort outputPort,
            IEnumerable<IValidator<DeleteCustomerParams>> validators) =>
            (CustomerRepository, UnitOfWork, OutputPort, Validators) =
            (customerRepository, unitOfWork, outputPort, validators);

        public async Task Handle(DeleteCustomerParams customer)
        {

            await Validator<DeleteCustomerParams>.Validate(customer, Validators);

           

           Customer customerDB = CustomerRepository.GetCustomersBySpecification(new CustomerByIdSpecification(customer.Id)).FirstOrDefault();
            if (customerDB == null)
                throw new GeneralException("Error al eliminar el cliente.", "No se encontro el cliente que desea eliminar.");

            CustomerRepository.Delete(customerDB);

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear el cliente.", ex.Message);
            }

            await OutputPort.Handle(true);
        }

    }

}
