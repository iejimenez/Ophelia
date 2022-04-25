using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Entities.Interfaces
{
    public interface IProductRepository
    {

        void Create(Product product);

        void Update(Product product);

        void Delete(Product product);
        IEnumerable<Product> GetProductsBySpecification(Specification<Product> specification);


    }
}
