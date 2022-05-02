using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts.Customer
{
    public interface IUpdateCustomerOutputPort
    {
        public Task Handle(bool updated);
    }
}
