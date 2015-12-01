using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities.POCOs;
using eRestaurant.Framework.Entities.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class WaiterController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<UnpaidBill> ListUnpaidBills()
        {
            using (var context = new RestaurantContext())
            {
                var result = from data in context.Bills
                             where !data.PaidStatus
                                && data.Items.Count() > 0
                             select new UnpaidBill()
                             {
                                 DisplayText = "Bill " + data.BillID.ToString(),
                                 BillID = data.BillID,

                             };
                return result.ToList();
            }
        }

        public Order GetBill(int billID)
        {
            using (var context = new RestaurantContext())
            {
                var result = from data in context.Bills
                             where data.BillID == billID //this would be billID that they ask for when           wanting to split
                             select new Order()
                             {
                                 BillID = data.BillID,
                                 //IEnumerable<OrderItem>
                                 Items = (from info in data.Items
                                          select new OrderItem()
                                          {
                                              ItemName = info.Item.Description,
                                              Price = info.SalePrice,
                                              Quantity = info.Quantity
                                          }).ToList()
                             };
                return result.FirstOrDefault();
            }
        }
    }

   
}
