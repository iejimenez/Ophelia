using Ophelia.UseCases.Common.Ports;
using Ophelia.UseCasesDTOs.Product.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.CustomerCases
{
    public class CreateCustomerInputPort : IInputPort<CreateCustomerParams, bool>
    {
        public CreateCustomerParams RequestData { get; }

        public IOutputPort<bool> OutputPort { get; }

        public CreateCustomerInputPort(CreateCustomerParams requestData, IOutputPort<bool> outputPort) =>
            (RequestData, OutputPort) = (requestData, outputPort);
    }
    
}
