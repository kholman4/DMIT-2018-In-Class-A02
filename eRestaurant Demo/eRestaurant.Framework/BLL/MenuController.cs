﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //for [DataObject] et.al attributes
using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities;
using System.Data.Entity;
using eRestaurant.Framework.Entities.DTO; //for the lambda version of the Include() method

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class MenuController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryDTO> ListMenuItems()
        {
            using (var context = new RestaurantContext())
            {
                var data = from cat in context.MenuCategories
                           orderby cat.Description
                           select new CategoryDTO() //use the DTO
                           {
                               Description = cat.Description,
                               MenuItems = from item in cat.Items
                                           where item.Active
                                           orderby item.Description
                                           select new MenuItemDTO
                                           {
                                               Description = item.Description,
                                               Price = item.CurrentPrice,
                                               Calories = item.Calories,
                                               Comment = item.Comment
                                           }
                           };
                return data.ToList();

                //Note: to use the Lambda or Method style of Include(), you need to have the following namespace reference: use System.Data.Entity;
                //The .Include() method on the DbSet<T> class performs "eager laoding" of the data.
                //return context.Items.Include(it => it.MenuCategory).ToList();
            }
        }
    }
}
