using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.UseCasesDTOs.Order.CreateOrder
{
    public class CreateOrderParams
    {
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }

        public List<CreateOrderDetailParams> OrderDetails { get; set; }
    }
}
