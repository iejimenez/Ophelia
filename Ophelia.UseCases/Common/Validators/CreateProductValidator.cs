using FluentValidation;
using Ophelia.UseCasesDTOs.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.Common.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductParams>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty()
                .WithMessage("Debe por el nombre del producto.");
            RuleFor(c => c.Name).NotEmpty()
                .MaximumLength(200)
                .WithMessage("El nombre debe ser de maximo 200 caracteres.");
        }
    }
}
