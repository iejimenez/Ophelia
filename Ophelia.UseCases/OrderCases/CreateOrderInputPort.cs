using MediatR;
using Ophelia.UseCases.Common.Ports;
using Ophelia.UseCasesDTOs.Order.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.OrderCases
{
    public class CreateOrderInputPort : IInputPort<CreateOrderParams, int>
    {
        public CreateOrderParams RequestData { get; }

        public IOutputPort<int> OutputPort { get; }

        public CreateOrderInputPort(CreateOrderParams requestData, IOutputPort<int> outputPort) =>
            (RequestData, OutputPort) = (requestData, outputPort);
    }
}
