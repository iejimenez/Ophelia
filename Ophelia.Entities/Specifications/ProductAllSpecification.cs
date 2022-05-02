using Ophelia.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Entities.Specifications
{
    public class ProductAllSpecification : Specification<Product>
    {
        public override System.Linq.Expressions.Expression<Func<Product, bool>> Expression => (x) => true;
    }
}
