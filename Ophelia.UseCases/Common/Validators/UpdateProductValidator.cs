using FluentValidation;
using Ophelia.UseCasesDTOs.Product.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.Common.Validators
{
    public class UpdateProductValidator  : AbstractValidator<UpdateProductParams>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage("Debe proporcionar el Id del producto.");
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Debe por el nombre del producto.");

            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Debe por el nombre del producto.");

        }
    }
}
