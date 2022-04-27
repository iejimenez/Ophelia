using FluentValidation;
using Ophelia.UseCasesDTOs.Product.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.Common.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerParams>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty()
                .WithMessage("Debe proporcionar el nombre del cliente.");

            RuleFor(c => c.BirthDate).NotNull()
                .WithMessage("Debe proporcionar una fecha de nacimiento.");
        }
    }
}
