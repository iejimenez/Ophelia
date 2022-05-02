using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts.Products
{
    public interface IDeleteProductOutputPort
    {
        public Task Handle(bool deleted);
    }
}
