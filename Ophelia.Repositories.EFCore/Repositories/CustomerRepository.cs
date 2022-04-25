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
    public class CustomerRepository : ICustomerRepository
    {
        readonly OpheliaContext Context;

        public CustomerRepository(OpheliaContext context) => Context = context; 

        public void Create(Customer customer)
        {
            Context.Add(customer);
        }

        public void Delete(Customer customer)
        {
            Context.Remove(customer);
        }

        public IEnumerable<Customer> GetCustomersBySpecification(Specification<Customer> specification)
        {
            Func<Customer, bool> ExpressionDelegate = specification.Expression.Compile();
            return Context.Customers.Where(ExpressionDelegate);
        }

        public void Update(Customer customer)
        {
            Context.Update(customer);
        }
    }
}
