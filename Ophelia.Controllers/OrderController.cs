
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ophelia.Presenters;
using Ophelia.UseCases.OrderCases;
using Ophelia.UseCasesDTOs.Order.CreateOrder;
using Ophelia.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ophelia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        readonly ICreateOrderInputPort CreateOrderInputPort;
        readonly ICreateOrderOutputPort CreateOrderOutputPort;
        public OrderController(ICreateOrderInputPort createOrderInputPort,
            ICreateOrderOutputPort createOrderrOutputPort) =>
            (CreateOrderInputPort, CreateOrderOutputPort) =
            (createOrderInputPort, createOrderrOutputPort);


        [HttpPost("create-order")]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderParams orderParams)
        {
            await CreateOrderInputPort.Handle(orderParams);
            var Presenter = CreateOrderOutputPort as CreateOrderPresenter;
            return Presenter.Content;
        }
    }
}
