﻿using Ophelia.Entities.POCOEntities;
using Ophelia.Entities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification);
    }
}
