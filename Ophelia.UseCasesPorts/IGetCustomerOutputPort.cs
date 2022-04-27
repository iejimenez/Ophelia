using Ophelia.UseCasesDTOs.Customer.GetCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts
{
    public interface IGetCustomerOutputPort
    {
        Task Handle(List<GetCustomerResponse> customers);
    }
}
