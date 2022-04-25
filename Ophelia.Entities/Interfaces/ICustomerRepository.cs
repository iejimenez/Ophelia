using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Entities.Interfaces
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);

        void Update(Customer customer);

        void Delete(Customer customer);
        IEnumerable<Customer> GetCustomersBySpecification(Specification<Customer> specification);
    }
}
