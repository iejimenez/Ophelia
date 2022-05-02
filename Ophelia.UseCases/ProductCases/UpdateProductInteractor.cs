
using FluentValidation;
using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using Ophelia.UseCasesDTOs.Product.UpdateProduct;
using Ophelia.UseCasesPorts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    public class UpdateProductInteractor : IUpdateProductInputPort
    {
        readonly IProductRepository ProductRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateProductOutputPort OutputPort;
        readonly IEnumerable<IValidator<UpdateProductParams>> Validators;

        public UpdateProductInteractor(IProductRepository productRepository,
            IUnitOfWork unitOfWork, IUpdateProductOutputPort updateProductOuputPort, IEnumerable<IValidator<UpdateProductParams>> validators) =>
            (ProductRepository, UnitOfWork, OutputPort, Validators) =
            (productRepository, unitOfWork, updateProductOuputPort, validators);

        public async Task Handle(UpdateProductParams product)
        {
          
            IEnumerable<Product> products = ProductRepository.GetProductsBySpecification(new ProductsByIdSpecification(product.Id));
            if (!products.Any())
                throw new GeneralException("Error al actualizar el producto.", "No se encontro el producto referenciado.");

            Product productDB = products.FirstOrDefault();
            productDB.Name = product.Name;
            productDB.Stock = product.Stock;
            productDB.UnitPrice = product.UnitPrice;
            
            ProductRepository.Update(productDB);

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear el producto.", ex.Message);
            }

            await OutputPort.Handle(true);
        }
    }
}
