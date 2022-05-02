using Ophelia.UseCasesPorts.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class DeleteCustomerPresenter : IDeleteCustomerOutputPort, IPresenter<bool>
    {
        public bool Content { get; private set; }


        Task IDeleteCustomerOutputPort.Handle(bool updated)
        {
            Content = updated;
            return Task.CompletedTask;
        }
    }
}
