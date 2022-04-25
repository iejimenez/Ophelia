using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ophelia.UseCases.OrderCases;
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
        readonly IMediator Mediator;

        public OrderController(IMediator mediator) => Mediator = mediator;
        

        [HttpPost("create-order")]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderInputPort orderParams)
        {
            return await Mediator.Send(orderParams);
        }
    }
}
