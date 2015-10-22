using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //comes with entity framework
using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities;
using eRestaurant.Framework.Entities.POCOs;
using eRestaurant.Framework.Entities.DTO;

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class ReservationsController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ActiveEvent> ListActiveEvents()
        {
            using (var context = new RestaurantContext())
            {
                var result = from eachRow in context.SpecialEvents
                             where eachRow.Active
                             select new ActiveEvent()
                             {
                                 Code = eachRow.EventCode,
                                 Description = eachRow.Description
                             };
                 return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<DailyReservation> ListUpcomingReservations(string eventCode)
        {
            using (var context = new RestaurantContext())
            {
                //Step 1 will be an object that generates SQL to run on the database
                var step1 = from eachRow in context.Reservations
                             where eachRow.ReservationStatus == "B"
                             orderby eachRow.ReservationDate
                             group eachRow by new { eachRow.ReservationDate.Month,     eachRow.ReservationDate.Day }; 

                             //By calling step1.ToList(), the results are brought into RAM (memory) for us to query as LINQ-To-Objects
                             var result = from dailyReservation in step1.ToList() 
                             select new DailyReservation()   
                                 {   
                                     Month = dailyReservation.Key.Month,
                                     Day = dailyReservation.Key.Day,
                                     Reservations = from booking in dailyReservation
                                                    select new Booking()
                                                    { 
                                                        Name = booking.CustomerName,
                                                        NumberInParty = booking.NumberInParty,
                                                        Time =  booking.ReservationDate.TimeOfDay,
                                                        Phone = booking.ContactPhone,
                                                        Event = booking.SpecialEvent == null ? (string)null : booking.SpecialEvent.Description //we are doing it in memory
                                                    }
                                 };
                return result.ToList();
            }
        }
    }
}
