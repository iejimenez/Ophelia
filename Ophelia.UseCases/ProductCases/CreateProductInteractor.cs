using MediatR;
using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    public class CreateProductInteractor : AsyncRequestHandler<CreateProductInputPort>
    { 
        
        readonly IProductRepository ProductRepository;
        readonly IUnitOfWork UnitOfWork;

        public CreateProductInteractor(IProductRepository productRepository,  
            IUnitOfWork unitOfWork) => 
            (ProductRepository, UnitOfWork) = 
            (productRepository,  unitOfWork);

        protected  async override Task Handle(CreateProductInputPort request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Name = request.RequestData.Name,
                Stock = request.RequestData.Stock,
                UnitPrice = request.RequestData.UnitPrice
            };

            ProductRepository.Create(product);
           
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear el producto.", ex.Message);
            }

            request.OutputPort.Handle(product.Id);
        }

    }
}
