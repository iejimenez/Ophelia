using Ophelia.UseCasesPorts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class CreateProductPresenter : ICreateProductOutputPort, IPresenter<int>
    {
        public int Content { get; private set; }
       
        Task ICreateProductOutputPort.Handle(int productId)
        {
            Content = productId;
            return Task.CompletedTask;
        }
    }
}
