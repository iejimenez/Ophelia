using Ophelia.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Entities.Specifications
{
    public class CustomerAllSpecification : Specification<Customer>
    {
        public override System.Linq.Expressions.Expression<Func<Customer, bool>> Expression => (x) => true;
    }
}
