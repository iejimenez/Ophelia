using Ophelia.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Entities.Specifications
{
    public class CustomerByIdSpecification : Specification<Customer>
    {
        readonly string Id;
        public CustomerByIdSpecification(string id)
        {
            Id = id;
        }
        public override Expression<Func<Customer, bool>> Expression => c => (c.Id == Id);
    }
}
