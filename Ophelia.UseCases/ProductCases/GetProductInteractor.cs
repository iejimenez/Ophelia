using Ophelia.Entities.Interfaces;
using Ophelia.Entities.Specifications;
using Ophelia.UseCasesDTOs.Product;
using Ophelia.UseCasesPorts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    public class GetProductInteractor : IGetProductInputPort
    {
        readonly IProductRepository PrpoductRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly IGetProductOutputPort OutputPort;

        public GetProductInteractor(IProductRepository productRepository,
            IUnitOfWork unitOfWork, IGetProductOutputPort outputPort) =>
            (PrpoductRepository, UnitOfWork, OutputPort) =
            (productRepository, unitOfWork, outputPort);

        public async Task Handle()
        {
            IEnumerable<GetProductResponse> products = PrpoductRepository.GetProductsBySpecification(new ProductAllSpecification())
                .Select(c => new GetProductResponse()
                {
                    Id = c.Id,
                    Name = c.Name,
                    UnitPrice = c.UnitPrice,
                    Stock = c.Stock
                });
            await OutputPort.Handle(products.ToList());
        }
    }
}
