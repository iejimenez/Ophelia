using MediatR;
using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    class UpdateProductInteractor : AsyncRequestHandler<UpdateProductInputPort>
    {
        readonly IProductRepository ProductRepository;
        readonly IUnitOfWork UnitOfWork;

        public UpdateProductInteractor(IProductRepository productRepository,
            IUnitOfWork unitOfWork) =>
            (ProductRepository, UnitOfWork) =
            (productRepository, unitOfWork);

        protected async override Task Handle(UpdateProductInputPort request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Id = request.RequestData.Id,
                Name = request.RequestData.Name,
                Stock = request.RequestData.Stock,
                UnitPrice = request.RequestData.UnitPrice
            };

            IEnumerable<Product> products = ProductRepository.GetProductsBySpecification(new ProductsAllSpecification(product.Id));
            if (!products.Any())
                throw new GeneralException("Error al actualizar el producto.", "No se encontro el producto referenciado.");

            ProductRepository.Update(product);

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear el producto.", ex.Message);
            }

            request.OutputPort.Handle(true);
        }

    }
}
