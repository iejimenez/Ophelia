using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesDTOs.CreateProduct
{
    public class CreateProductParams
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public int Stock { get; set; }
    }
}
