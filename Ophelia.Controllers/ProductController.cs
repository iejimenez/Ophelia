using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ophelia.Presenters;
using Ophelia.UseCases.ProductCases;
using Ophelia.UseCasesDTOs.CreateProduct;
using Ophelia.UseCasesPorts.Products;
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

        readonly ICreateProductInputPort CreateProductInputPort;
        readonly ICreateProductOutputPort CreateProductOutputPort;
        public ProductController(ICreateProductInputPort createProductInputPort,
            ICreateProductOutputPort createProductOutputPort) =>
            (CreateProductInputPort, CreateProductOutputPort) =
            (createProductInputPort, createProductOutputPort);

        [HttpPost("create-product")]
        public async Task<ActionResult<int>> CreateProduct(CreateProductParams productParams)
        {
            await CreateProductInputPort.Handle(productParams);
            var Presenter = CreateProductOutputPort as CreateProductPresenter;
            return Presenter.Content;
        }
    }
}
