﻿using System;
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
        #region Manage Special Events (CRUD)
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

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateSpecialEvent(SpecialEvent item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                //First attach the item to the dbContext collection
                var attached = context.SpecialEvents.Attach(item);

                //Second, get the entry for the existing data that should match for this specific special event
                var existing = context.Entry<SpecialEvent>(attached);

                //Third, mark that the object's values have changed
                existing.State = System.Data.Entity.EntityState.Modified;

                //Lastly, save the changes in the database
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteSpecialEvent(SpecialEvent item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                //First give a reference to the actual item in the DB
                //Find() is a method to look up an item by its primary key
                var existing = context.SpecialEvents.Find(item.EventCode);

                //Second, remove the item from the DB context
                context.SpecialEvents.Remove(existing);

                //Lastly, save the changes to the database
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void InsertSpecialEvent(SpecialEvent item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                //Add the item to the DBcontext
                var added = context.SpecialEvents.Add(item);

                //PS we arent really going to do anything with the variable 'added', I just want you to be aware that the Add() method will return the newly added object. (This can be useful in other situations, which we will see later)

                //Save the changes to the database
                context.SaveChanges();
            }
        }
        #endregion

        #region Manage Waiters (CRUD)
        //The ObjectDataSource control will do the background communication for CRUD operations
        //This method allows the ObjectDataSource to see the method as something we can select from

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Waiter> ListAllWaiters()
        {
            //This "using" statement ensures that our connection to the database is properly "closed" once we are done using our DAL object
            //Context is our DAL object
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.Waiters.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateWaiter(Waiter item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                //First attach the item to the dbContext collection
                var attached = context.Waiters.Attach(item);

                //Second, get the entry for the existing data that should match for this specific special event
                var existing = context.Entry<Waiter>(attached);

                //Third, mark that the object's values have changed
                existing.State = System.Data.Entity.EntityState.Modified;

                //Lastly, save the changes in the database
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteWaiter(Waiter item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                //First give a reference to the actual item in the DB
                //Find() is a method to look up an item by its primary key
                var existing = context.Waiters.Find(item.WaiterID);

                //Second, remove the item from the DB context
                context.Waiters.Remove(existing);

                //Lastly, save the changes to the database
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void InsertWaiter(Waiter item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                //Add the item to the DBcontext
                var added = context.Waiters.Add(item);

                //PS we arent really going to do anything with the variable 'added', I just want you to be aware that the Add() method will return the newly added object. (This can be useful in other situations, which we will see later)

                //Save the changes to the database
                context.SaveChanges();
            }
        }

        #endregion

    }
}
