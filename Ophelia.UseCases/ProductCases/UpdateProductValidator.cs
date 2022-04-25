using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductInputPort>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.RequestData.Id)
                .GreaterThan(0)
                .WithMessage("Debe proporcionar el Id del producto.");
            RuleFor(c => c.RequestData.Name)
                .NotEmpty()
                .WithMessage("Debe por el nombre del producto.");

            RuleFor(c => c.RequestData.Name)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Debe por el nombre del producto.");

        }
    }

}
