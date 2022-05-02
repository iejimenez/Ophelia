
using Microsoft.AspNetCore.Mvc;
using Ophelia.Presenters;
using Ophelia.UseCases.CustomerCases;
using Ophelia.UseCasesDTOs;
using Ophelia.UseCasesDTOs.Customer.GetCustomer;
using Ophelia.UseCasesDTOs.Customer.UpdateCustomer;
using Ophelia.UseCasesDTOs.Product.CreateCustomer;
using Ophelia.UseCasesPorts;
using Ophelia.UseCasesPorts.Customer;
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

        readonly IUpdateCustomerInputPort UpdateCustomerInputPort;
        readonly IUpdateCustomerOutputPort UpdateCustomerOutputPort;

        readonly IDeleteCustomerInputPort DeleteCustomerInputPort;
        readonly IDeleteCustomerOutputPort DeleteCustomerOutputPort;

        readonly IGetCustomerInputPort GetCustomersInputPort;
        readonly IGetCustomerOutputPort GetCustomerOutputPort;
        public CustomerController(ICreateCustomerInputPort createCustomerInputPort,
            ICreateCustomerOutputPort createCustomerOutputPort,
            IGetCustomerInputPort getCustomersInputPort,
            IUpdateCustomerInputPort updateCustomerInputPort,
            IUpdateCustomerOutputPort updateCustomerOutputPort,
            IDeleteCustomerInputPort deleteCustomerInputPort,
            IDeleteCustomerOutputPort deleteCustomerOutputPort,

        IGetCustomerOutputPort getCustomerOutputPort) =>
            (CreateCustomerInputPort, CreateCustomerOutputPort, GetCustomersInputPort, GetCustomerOutputPort,
            UpdateCustomerInputPort, UpdateCustomerOutputPort, DeleteCustomerInputPort, DeleteCustomerOutputPort) =
            (createCustomerInputPort, createCustomerOutputPort, getCustomersInputPort, getCustomerOutputPort, 
            updateCustomerInputPort, updateCustomerOutputPort, deleteCustomerInputPort, deleteCustomerOutputPort);


        [HttpPost("create-customer")]
        public async Task<string> CreateCustomer(CreateCustomerParams customerParams)
        {
            await CreateCustomerInputPort.Handle(customerParams);
            var Presenter = CreateCustomerOutputPort as CreateCustomerPresenter;
            return Presenter.Content;
        }

        [HttpPut("update-customer")]
        public async Task<bool> UpdateCustomer(UpdateCustomerParams customerParams)
        {
            await UpdateCustomerInputPort.Handle(customerParams);
            var Presenter = UpdateCustomerOutputPort as UpdateCustomerPresenter;
            return Presenter.Content;
        }


        [HttpDelete("delete-customer")]
        public async Task<bool> DeleteCustomer(DeleteCustomerParams customerParams)
        {
            await DeleteCustomerInputPort.Handle(customerParams);
            var Presenter = DeleteCustomerOutputPort as DeleteCustomerPresenter;
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
