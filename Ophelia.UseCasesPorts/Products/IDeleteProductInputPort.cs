using Ophelia.UseCasesDTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts.Products
{
    public interface IDeleteProductInputPort
    {
        Task Handle(DeleteProductParams product);
    }
}
