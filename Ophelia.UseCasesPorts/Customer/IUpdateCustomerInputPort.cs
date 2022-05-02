using Ophelia.UseCasesDTOs.Customer.UpdateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts.Customer
{
    public interface IUpdateCustomerInputPort
    {
        Task Handle(UpdateCustomerParams customer);
    }
}
