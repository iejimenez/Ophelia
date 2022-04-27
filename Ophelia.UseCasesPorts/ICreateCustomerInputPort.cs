using Ophelia.UseCasesDTOs.Product.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts
{
    public interface ICreateCustomerInputPort
    {
        Task Handle(CreateCustomerParams customer);
    }
}
