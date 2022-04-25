using Ophelia.UseCases.Common.Ports;
using Ophelia.UseCasesDTOs.Product.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCases.ProductCases
{
    public class UpdateProductInputPort : IInputPort<UpdateProductParams, bool>
    {
        public UpdateProductParams RequestData { get; }

        public IOutputPort<bool> OutputPort { get; }

        public UpdateProductInputPort(UpdateProductParams requestData, IOutputPort<bool> outputPort) =>
            (RequestData, OutputPort) = (requestData, outputPort);
    }
    
}
