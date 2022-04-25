using MediatR;
using Ophelia.UseCases.Common.Ports;
using Ophelia.UseCasesDTOs.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    public class CreateProductInputPort : IInputPort<CreateProductParams, int>
    {
        public CreateProductParams RequestData { get; }

        public IOutputPort<int> OutputPort { get; }

        public CreateProductInputPort(CreateProductParams requestData, IOutputPort<int> outputPort) =>
            (RequestData, OutputPort) = (requestData, outputPort);
    }
}
