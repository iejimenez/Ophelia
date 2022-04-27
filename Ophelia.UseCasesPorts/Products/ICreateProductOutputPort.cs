using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts.Products
{
    public interface ICreateProductOutputPort
    {
        Task Handle(int productId);
    }
}
