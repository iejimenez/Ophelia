using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ophelia.Presenters;
using Ophelia.UseCases.ProductCases;
using Ophelia.UseCasesDTOs.CreateProduct;
using Ophelia.UseCasesDTOs.Product;
using Ophelia.UseCasesDTOs.Product.UpdateProduct;
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

        readonly IUpdateProductInputPort UpdateProductInputPort;
        readonly IUpdateProductOutputPort UpdateProductOutputPort;

        readonly IDeleteProductInputPort DeleteProductInputPort;
        readonly IDeleteProductOutputPort DeleteProductOutputPort;

        readonly IGetProductInputPort GetProductsInputPort;
        readonly IGetProductOutputPort GetProductOutputPort;
        public ProductController(ICreateProductInputPort createProductInputPort,
            ICreateProductOutputPort createProductOutputPort,
            IGetProductInputPort getProductsInputPort,
            IUpdateProductInputPort updateProductInputPort,
            IUpdateProductOutputPort updateProductOutputPort,
            IDeleteProductInputPort deleteProductInputPort,
            IDeleteProductOutputPort deleteProductOutputPort,

        IGetProductOutputPort getProductOutputPort) =>
            (CreateProductInputPort, CreateProductOutputPort, GetProductsInputPort, GetProductOutputPort,
            UpdateProductInputPort, UpdateProductOutputPort, DeleteProductInputPort, DeleteProductOutputPort) =
            (createProductInputPort, createProductOutputPort, getProductsInputPort, getProductOutputPort,
            updateProductInputPort, updateProductOutputPort, deleteProductInputPort, deleteProductOutputPort);


        [HttpPost("create-product")]
        public async Task<int> CreateProduct(CreateProductParams productParams)
        {
            await CreateProductInputPort.Handle(productParams);
            var Presenter = CreateProductOutputPort as CreateProductPresenter;
            return Presenter.Content;
        }

        [HttpPut("update-product")]
        public async Task<bool> UpdateProduct(UpdateProductParams productParams)
        {
            await UpdateProductInputPort.Handle(productParams);
            var Presenter = UpdateProductOutputPort as UpdateProductPresenter;
            return Presenter.Content;
        }


        [HttpDelete("delete-product")]
        public async Task<bool> DeleteProduct(DeleteProductParams productParams)
        {
            await DeleteProductInputPort.Handle(productParams);
            var Presenter = DeleteProductOutputPort as DeleteProductPresenter;
            return Presenter.Content;
        }


        [HttpGet("get-all-products")]
        public async Task<List<GetProductResponse>> GetAllCustomer()
        {
            await GetProductsInputPort.Handle();
            var Presenter = GetProductOutputPort as GetProductPresenter;
            return Presenter.Content;
        }
    }
}
