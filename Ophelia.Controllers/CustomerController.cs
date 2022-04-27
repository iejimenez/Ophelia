
using Microsoft.AspNetCore.Mvc;
using Ophelia.Presenters;
using Ophelia.UseCases.CustomerCases;
using Ophelia.UseCasesDTOs.Customer.GetCustomer;
using Ophelia.UseCasesDTOs.Product.CreateCustomer;
using Ophelia.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController
    {
        readonly ICreateCustomerInputPort CreateCustomerInputPort;
        readonly ICreateCustomerOutputPort CreateCustomerOutputPort;
        readonly IGetCustomerInputPort GetCustomersInputPort;
        readonly IGetCustomerOutputPort GetCustomerOutputPort;
        public CustomerController(ICreateCustomerInputPort createCustomerInputPort,
            ICreateCustomerOutputPort createCustomerOutputPort,
            IGetCustomerInputPort getCustomersInputPort,
            IGetCustomerOutputPort getCustomerOutputPort) =>
            (CreateCustomerInputPort, CreateCustomerOutputPort, GetCustomersInputPort, GetCustomerOutputPort) =
            (createCustomerInputPort, createCustomerOutputPort, getCustomersInputPort, getCustomerOutputPort);


        [HttpPost("create-customer")]
        public async Task<string> CreateCustomer(CreateCustomerParams customerParams)
        {
            await CreateCustomerInputPort.Handle(customerParams);
            var Presenter = CreateCustomerOutputPort as CreateCustomerPresenter;
            return Presenter.Content;
        }


        [HttpGet("get-all-customers")]
        public async Task<List<GetCustomerResponse>> GetAllCustomer()
        {
            await GetCustomersInputPort.Handle();
            var Presenter = GetCustomerOutputPort as GetCustomerPresenter;
            return Presenter.Content;
        }
    }
}
