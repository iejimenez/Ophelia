
using Ophelia.UseCasesDTOs.Product;
using Ophelia.UseCasesPorts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class GetProductPresenter : IGetProductOutputPort, IPresenter<List<GetProductResponse>>
    {
        public List<GetProductResponse> Content { get; private set; }
        
        public Task Handle(List<GetProductResponse> products)
        {
            Content = products;
            return Task.CompletedTask;
        }
    }
}
