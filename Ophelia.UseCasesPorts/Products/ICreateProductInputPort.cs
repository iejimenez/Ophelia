using Ophelia.UseCasesDTOs.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts.Products
{
    public interface ICreateProductInputPort
    {
        Task Handle(CreateProductParams product);
    }
}
