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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly OpheliaContext Context;
        public void Create(OrderDetail detail)
        {
            Context.Add(detail);
        }

        public IEnumerable<OrderDetail> GetOrderDetailsBySpecification(Specification<OrderDetail> specification)
        {
            return Context.OrderDetails.Where(od=>specification.ISSatisfiedBy(od));
        }
    }
}
