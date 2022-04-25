using Ophelia.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Entities.Specifications
{
    public class ProductsAllSpecification : Specification<Product>
    {
        readonly int Id;
        public ProductsAllSpecification(int id) {
            Id = id;
        }
        public override Expression<Func<Product, bool>> Expression => p => (p.Id == Id);
    }
}
