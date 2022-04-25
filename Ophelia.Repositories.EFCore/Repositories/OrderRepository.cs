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
    public class OrderRepository : IOrderRepository
    {
        readonly OpheliaContext Context;

        public OrderRepository(OpheliaContext context) => Context = context;
        public void Create(Order order)
        {
            Context.Add(order);
        }

        public IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification)
        {
            Func<Order, bool> ExpressionDelegate = specification.Expression.Compile();
            return Context.Orders.Where(ExpressionDelegate);
        }
    }
}
