using Ophelia.UseCasesDTOs.Product.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts.Products
{
    public interface IUpdateProductInputPort
    {
        Task Handle(UpdateProductParams product);
    }
}
