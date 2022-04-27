
using FluentValidation;
using Ophelia.Entities.Exceptions;
using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.UseCases.Common.Validators;
using Ophelia.UseCasesDTOs.CreateProduct;
using Ophelia.UseCasesPorts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    public class CreateProductInteractor : ICreateProductInputPort
    { 
        
        readonly IProductRepository ProductRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateProductOutputPort OutputPort;
        readonly IEnumerable<IValidator<CreateProductParams>> Validators;

        public CreateProductInteractor(IProductRepository productRepository,  
            IUnitOfWork unitOfWork, ICreateProductOutputPort outputPort,
            IEnumerable<IValidator<CreateProductParams>> validators) => 
            (ProductRepository, UnitOfWork, OutputPort, Validators) = 
            (productRepository,  unitOfWork, outputPort, validators);

        public async Task Handle(CreateProductParams product)
        {
            await Validator<CreateProductParams>.Validate(product, Validators);

            Product productDB = new Product()
            {
                Name = product.Name,
                Stock = product.Stock,
                UnitPrice = product.UnitPrice
            };

            ProductRepository.Create(productDB);

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear el producto.", ex.Message);
            }

            await OutputPort.Handle(productDB.Id);
        }


    }
}
