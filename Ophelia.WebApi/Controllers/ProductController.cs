using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ophelia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        readonly IMediator Mediator;

        public ProductController(IMediator mediator) => Mediator = mediator;

        [HttpPost("create-product")]
        public async Task<ActionResult<int>> CreateOrder(CreateProductParams orderParams)
        {
            return await Mediator.Send(orderParams);
        }
    }
}
