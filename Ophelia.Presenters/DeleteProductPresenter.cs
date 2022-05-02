using Ophelia.UseCasesPorts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class DeleteProductPresenter : IDeleteProductOutputPort, IPresenter<bool>
    {
        public bool Content { get; private set; }


        Task IDeleteProductOutputPort.Handle(bool deleted)
        {
            Content = deleted;
            return Task.CompletedTask;
        }
    }
}
