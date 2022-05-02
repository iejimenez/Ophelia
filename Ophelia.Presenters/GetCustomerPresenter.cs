
using Ophelia.UseCasesDTOs.Customer.GetCustomer;
using Ophelia.UseCasesDTOs.Product;
using Ophelia.UseCasesPorts.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class GetCustomerPresenter : IGetCustomerOutputPort, IPresenter<List<GetCustomerResponse>>
    {
        public List<GetCustomerResponse> Content { get; private set; }
        
        public Task Handle(List<GetCustomerResponse> customers)
        {
            Content = customers;
            return Task.CompletedTask;
        }
    }
}
