using FluentValidation;
using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using Ophelia.UseCases.Common.Validators;
using Ophelia.UseCasesDTOs.Product;
using Ophelia.UseCasesPorts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    public class DeleteProductInteractor : IDeleteProductInputPort
    {
        readonly IProductRepository ProductRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IDeleteProductOutputPort OutputPort;
        readonly IEnumerable<IValidator<DeleteProductParams>> Validators;

        public DeleteProductInteractor(IProductRepository productRepository,
           IUnitOfWork unitOfWork, IDeleteProductOutputPort updateProductOuputPort, IEnumerable<IValidator<DeleteProductParams>> validators) =>
           (ProductRepository, UnitOfWork, OutputPort, Validators) =
           (productRepository, unitOfWork, updateProductOuputPort, validators);

        public async Task Handle(DeleteProductParams product)
        {
            await Validator<DeleteProductParams>.Validate(product, Validators);


            Product customerDB = ProductRepository.GetProductsBySpecification(new ProductsByIdSpecification(product.Id)).FirstOrDefault();
            if (customerDB == null)
                throw new GeneralException("Error al eliminar el procucto.", "No se encontro el procucto que desea eliminar.");

            ProductRepository.Delete(customerDB);

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al eliminar el producto.", ex.Message);
            }

            await OutputPort.Handle(true);
        }
    }
}
