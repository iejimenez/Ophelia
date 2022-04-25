using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    public class CreateProductValidator : AbstractValidator<CreateProductInputPort>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.RequestData.Name).NotEmpty()
                .WithMessage("Debe por el nombre del producto.");
            RuleFor(c => c.RequestData.Name).NotEmpty()
                .MaximumLength(200)
                .WithMessage("El nombre debe ser de maximo 200 caracteres.");
        }
    }
}
