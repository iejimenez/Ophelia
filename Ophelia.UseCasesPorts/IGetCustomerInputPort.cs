using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesPorts
{
    public interface IGetCustomerInputPort
    {
        Task Handle();
    }
}
