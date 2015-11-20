using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurant.Framework.Entities.DTO;
using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities;

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class SeatingController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SeatingSummary> SeatingByDateTime(DateTime date, TimeSpan time)
        {
            using (var context = new RestaurantContext())
            {

                #region Adapted From LinqPad
                //Step 1 - Get the table info along with any walk-in bills and reservation bills for a specific time slot
                
                var step1 = from Table data in context.Tables //since the data type of context.Tables is a dBSet of Table, that means I can add a bit of extra to my LINQ query to declare that the variable "data" is of type Table
                            select new
                            {
                                Table = data.TableNumber,
                                Seating = data.Capacity,

                                //This sub-query gets the bills for walk-in customers
                                WalkIns = from Bill walkin in data.Bills
                                          where walkin.BillDate.Year == date.Year
                                          && walkin.BillDate.Month == date.Month
                                          && walkin.BillDate.Day == date.Day
                                          && (!walkin.OrderPaid.HasValue || walkin.OrderPaid.Value >= time) //order paid is null OR order paid value is greater than current time
                                          select walkin,
                                
                                //This subquery gets the bills for reservations
                                Reservations = from Reservation booking in data.Reservations
                                               from reservationParty in booking.Bills
                                               where reservationParty.BillDate.Year == date.Year
                                               && reservationParty.BillDate.Month == date.Month
                                               && reservationParty.BillDate.Day == date.Day
                                               && (!reservationParty.OrderPaid.HasValue || reservationParty.OrderPaid >= time)
                                               select reservationParty
                            };
                //step1.Dump("Results of step 1");


                //Step 2 - Union the walk-in bills with the reservation bills while extracting the relevant bill info
                // 			.ToList() helps resolve the error "Types in Union or Concat are constructed incompatibly"
                //the union will work because WalkIns and Reservations are formatted the same (they are essentially BIll Objects)

                var step2 = from data in step1.ToList() //this will force step1 into RAM
                            select new
                            {
                                Table = data.Table,
                                Seating = data.Seating,
                                CommonBilling = from Bill info in data.WalkIns.Union(data.Reservations)
                                                select new //trimmed down billing information
                                                {
                                                    BillID = info.BillID,
                                                    BillTotal = info.Items.Sum(bi => bi.Quantity * bi.SalePrice),
                                                    Waiter = info.Waiter.FirstName,
                                                    Reservation = info.Reservation
                                                }
                            };
                //step2.Dump("Results of step 2");

                //Step 3 - Get just the first CommonBilling item
                //			(assuming no overlaps can occur - i.e. two groups at the same table at the same time)
                //*changes it from being a list into an actual object

                var step3 = from data in step2.ToList()
                            select new
                            {
                                Table = data.Table,
                                Seating = data.Seating,
                                Taken = data.CommonBilling.Count() > 0,
                                //FirstOrDefault() is effectively "flattening" my collection of 1 item into a single
                                //object whose properties I can get in Step 4 using the dot (.) operator
                                CommonBilling = data.CommonBilling.FirstOrDefault()
                            };
                //step3.Dump("Results of step 3");



                //Step 4 - Build our intended seating summary info

                var step4 = from data in step3
                            select new SeatingSummary() //the DTO class to use in my BLL
                            {
                                Table = data.Table,
                                Seating = data.Seating,
                                Taken = data.Taken,
                                //use a ternary expression to conditionally get the bill id (if it exists)
                                BillID = data.Taken ? //if data.Taken
                                         data.CommonBilling.BillID //use the bill id if it is taken
                                         : (int?)null, //otherwise, use this if taken is false
                                BillTotal = data.Taken ? data.CommonBilling.BillTotal : (decimal?)null,
                                Waiter = data.Taken ? data.CommonBilling.Waiter : (string)null,
                                ReservationName = data.Taken ?
                                                (data.CommonBilling.Reservation != null ?
                                                    data.CommonBilling.Reservation.CustomerName :
                                                    (string)null)
                                                : (string)null
                            };
                //step4.Dump("Results of step 4");

                return step4.ToList();
                #endregion
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReservationCollection> ReservationsByTime(DateTime date)
        {
            using (var context = new RestaurantContext())
            {
                var result = from eachRow in context.Reservations
                             where eachRow.ReservationDate.Year == date.Year
                                 && eachRow.ReservationDate.Month == date.Month
                                 && eachRow.ReservationDate.Day == date.Day
                                 && eachRow.ReservationStatus == Reservation.Booked //reservation is booked
                             select new ReservationSummary() //DTO
                             {
                                 Name = eachRow.CustomerName,
                                 Date = eachRow.ReservationDate,
                                 NumberInParty = eachRow.NumberInParty,
                                 Status = eachRow.ReservationStatus.ToString(),
                                 Event = eachRow.SpecialEvent.Description,
                                 Contact = eachRow.ContactPhone
                             };

                var finalResult = from eachItem in result
                                  group eachItem by eachItem.Date.Hour into itemGroup
                                  select new ReservationCollection
                                  {
                                      Hour = itemGroup.Key,
                                      Reservations = itemGroup.ToList()
                                  };
                return finalResult.ToList();
            }
        } 
        
    }
}
