using Ophelia.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class CreateOrderPresenter : ICreateOrderOutputPort,  IPresenter<int>
    {
        public int Content { get; private set; }
      

        Task ICreateOrderOutputPort.Handle(int orderId)
        {
            Content = orderId;
            return Task.CompletedTask;
        }
    }
}
