using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class MenuController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Item> ListMenuItems()
        {
            using (var context = new RestaurantContext())
            {
                //Note: to use the Lambda or Method style of Include, you need to use the 
                //System.Data.Entity 
                //return context.Items.Include(it => it.Category).ToList();
            }
        }
    }
}
