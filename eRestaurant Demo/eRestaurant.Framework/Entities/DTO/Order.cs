using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurant.Framework.Entities.POCOs;

namespace eRestaurant.Framework.Entities.DTO
{
    public class Order
    {
        public int BillID { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
