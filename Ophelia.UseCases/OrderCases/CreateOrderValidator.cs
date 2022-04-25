using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.OrderCases
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.RequestData.CustomerId).NotEmpty()
                .WithMessage("Debe proporcionar la identificación del cliente");

            RuleFor(c => c.RequestData.CustomerId).NotEmpty().MinimumLength(3)
                .WithMessage("La identificacion del cliente es muy corta. Minimo 3 caracteres.");

            RuleFor(c => c.RequestData.CustomerId).NotEmpty().MaximumLength(12)
                .WithMessage("La identificacion del cliente es muy larga. Mximo 12 caracteres.");

            RuleFor(c => c.RequestData.OrderDetails)
                .Must(d => d != null && d.Any())
                .WithMessage("Deben especificarse los productos de la orden.");
        }
    }
}
