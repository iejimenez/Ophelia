using FluentValidation;
using Ophelia.UseCasesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.Common.Validators
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerParams>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
                .WithMessage("Debe proporcionar la identificación del cliente.");

            RuleFor(c => c.Id).NotEmpty().MaximumLength(12)
                .WithMessage("La identificación debe ser de maximo 12 caracteres.");

           
        }
    }
}
