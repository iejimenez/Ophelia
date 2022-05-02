using FluentValidation;
using Ophelia.UseCasesDTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.Common.Validators
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductParams>
    {
        public DeleteProductValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
                .WithMessage("Debe proporcionar la identificación del producto.");

        }
    }
}
