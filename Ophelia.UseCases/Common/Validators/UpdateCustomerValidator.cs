using FluentValidation;
using Ophelia.UseCasesDTOs.Customer.UpdateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.Common.Validators 
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerParams>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
               .WithMessage("Debe proporcionar la identificación del cliente.");

            RuleFor(c => c.Id).NotEmpty().MaximumLength(12)
                .WithMessage("La identificación debe ser de maximo 12 caracteres.");

            RuleFor(c => c.Name).NotEmpty()
                .WithMessage("Debe proporcionar el nombre del cliente.");

            RuleFor(c => c.Name).NotEmpty().MaximumLength(200)
                .WithMessage("El nombre debe tener maximo 200 caracteres.");

            RuleFor(c => c.BirthDate).NotNull()
                .WithMessage("Debe proporcionar una fecha de nacimiento.");
        }
    }
}
