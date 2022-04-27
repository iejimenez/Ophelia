using Ophelia.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class CreateCustomerPresenter : ICreateCustomerOutputPort, IPresenter<string>
    {

        public string Content { get; private set; }
        

        Task ICreateCustomerOutputPort.Handle(string created)
        {
            Content = created;
            return Task.CompletedTask;
        }
    }
}
