using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Presenters
{
    public class CreateProductPresenter : IPresenter<int, int>
    {
        public int Content { get; private set; }
        public void Handle(int response)
        {
            Content = response;
        }
    }
}
