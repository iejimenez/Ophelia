using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class UpdateProductoPresenter : IPresenter<bool, bool>
    {
        public bool Content { get; private set; }
        public void Handle(bool response)
        {
            Content = response;
        }
    }
}
