using Ophelia.UseCasesPorts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class UpdateProductPresenter : IUpdateProductOutputPort, IPresenter<bool>
    {
        public bool Content { get; private set; }
        

        Task IUpdateProductOutputPort.Handle(bool updated)
        {
            Content = updated;
            return Task.CompletedTask;
        }
    }
}
