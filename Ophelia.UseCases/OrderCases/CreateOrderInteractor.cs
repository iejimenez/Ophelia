using MediatR;
using Ophelia.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Exceptions;

namespace Ophelia.UseCases.OrderCases
{
    public class CreateOrderInteractor :  AsyncRequestHandler<CreateOrderInputPort> 
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;

        public CreateOrderInteractor(IOrderRepository orderRepository, 
            IOrderDetailRepository orderDetailRepository, 
            IUnitOfWork unitOfWork) => 
            (OrderRepository, OrderDetailRepository, UnitOfWork) = 
            (orderRepository, orderDetailRepository, unitOfWork);

        protected async override Task Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order order = new Order()
            {
                CustomerId = request.RequestData.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.RequestData.ShipAddress
            };

            OrderRepository.Create(order);
            foreach(var orderDetail in request.RequestData.OrderDetails)
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

            request.OutputPort.Handle(order.Id);
        }
    }
}
