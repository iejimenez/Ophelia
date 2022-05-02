using Ophelia.Entities.Interfaces;
using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using Ophelia.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Repositories.EFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly OpheliaContext Context;

        public ProductRepository(OpheliaContext context) => Context = context;
        public void Create(Product product)
        {
            Context.Add(product);
        }

        public void Delete(Product product)
        {
            Context.Remove(product);
        }

        public IEnumerable<Product> GetProductsBySpecification(Specification<Product> specification)
        {
            return Context.Products.Where(specification.Expression);
        }

        public void Update(Product product)
        {
            Context.Update(product);
        }
    }
}
