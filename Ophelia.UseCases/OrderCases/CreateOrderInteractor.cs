
using Ophelia.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Exceptions;
using Ophelia.UseCasesPorts;
using Ophelia.UseCasesDTOs.Order.CreateOrder;
using FluentValidation;
using Ophelia.UseCases.Common.Validators;

namespace Ophelia.UseCases.OrderCases
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateOrderOutputPort OutputPort;
        readonly IEnumerable<IValidator<CreateOrderParams>> Validators;

        public CreateOrderInteractor(IOrderRepository orderRepository, 
            IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork,
            IEnumerable<IValidator<CreateOrderParams>> validators) => 
            (OrderRepository, OrderDetailRepository, UnitOfWork, Validators) = 
            (orderRepository, orderDetailRepository, unitOfWork, validators);


        public async Task Handle(CreateOrderParams order)
        {

            await Validator<CreateOrderParams>.Validate(order, Validators);

            Order orderDB = new Order()
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = order.ShipAddress
            };

            OrderRepository.Create(orderDB);
            foreach (var orderDetail in order.OrderDetails)
            {
                OrderDetailRepository.Create(new OrderDetail()
                {
                    ProductId = orderDetail.ProductId,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.UnitPrice
                });
            }

            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }

            await OutputPort.Handle(orderDB.Id);
        }
    }
}
