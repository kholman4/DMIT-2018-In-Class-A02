using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities.POCOs;
using eRestaurant.Framework.Entities.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurant.Framework.Entities;

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

        public void SplitBill(int billID, List<OrderItem> originalBillItems, List<OrderItem> newBillItems)
        {
            //Split the bill in two...
            using (var context = new RestaurantContext())
            {
                //TODO: Validation
                //1) Get the bill
                var bill = context.Bills.Find(billID);
                if(bill == null) throw new ArgumentException("invalid bill ID - does not exist");             
                //2)Loop through bill items, if item not in original, remove
                List<BillItem> toRemove = new List<BillItem>();

                //this loop identifies/references each item to remove
                foreach(var item in bill.Items) //the items already in the DB
                {
                    bool inOriginal = originalBillItems.Any(x => x.ItemName == item.Item.Description);
                    bool inNewItems = newBillItems.Any(x => x.ItemName == item.Item.Description);

                    if(!inOriginal)
                    {
                        if (!inNewItems)
                            throw new Exception("Hey - someone's got to pay for that!");
                        toRemove.Add(item);
                    }
                }

                foreach(var item in toRemove)
                {
                    context.BillItems.Remove(item);
                }

                //3)Make a new bill
                var newBill = new Bill()
                {
                    BillDate = bill.BillDate, //some info from the original bill
                    Comment = "Split from bill number: " + bill.BillID,
                    NumberInParty = bill.NumberInParty,
                    OrderPlaced = bill.OrderPlaced,
                    OrderReady = bill.OrderReady,
                    OrderServed = bill.OrderServed,
                    WaiterID = bill.WaiterID
                    //TODO: tough question about rules around splitting the bill for a single table vs. reservation
                };

                //4)Add the new moved items to the new bill
                foreach (var item in toRemove)
                {
                    newBill.Items.Add(new BillItem()
                    {
                        ItemID = item.ItemID,
                        Notes = item.Notes,
                        Quantity = item.Quantity,
                        SalePrice = item.SalePrice,
                        UnitCost = item.UnitCost
                    });
                }

                //5)Add the new bill to the context
                context.Bills.Add(newBill);

                //6) Save the changes...
                context.SaveChanges(); //call this only ONCE at the end - TRANSACTION
            }
        }
    }

   
}
