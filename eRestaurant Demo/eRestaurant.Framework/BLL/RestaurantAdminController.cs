using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities;
using System.ComponentModel; //needed for [DataObject and related attribute classes

namespace eRestaurant.Framework.BLL
{
    //This attirubte allows our class to be discovered by the ObjectDataSource controls in our website
    [DataObject]
    public class RestaurantAdminController
    {
        //The ObjectDataSource control will do the background communication for CRUD operations
        //This method allows the ObjectDataSource to see the method as something we can select from
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> ListAllSpecialEvents()
        {
            //This "using" statement ensures that our connection to the database is properly "closed" once we are done using our DAL object
            //Context is our DAL object
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.SpecialEvents.ToList();
            }
        }

    }
}
