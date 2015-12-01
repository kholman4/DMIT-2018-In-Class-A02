using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities.DTO
{
    public class SeatingSummary
    {
        public int Table { get; set; } //the table number
        public int Seating { get; set; } //the seating capacity - Tables.Capacity
        public bool Taken { get; set; } //calculated based upon whethere the table is occupied
        public int? BillID { get; set; } //Bills.BillID (nullable)
        public decimal? BillTotal { get; set; } //calculated - total bill (nullable)
        public string Waiter { get; set; } //Waiter's name
        public string ReservationName { get; set; } //Reservations.ContactName (nullable)

        //We got the above information from the fields in step 3
        //Step 3
        //Table = data.Table,
        //        Capacity = data.Capacity,
        //        Taken = data.Taken,
        //        //use a ternary expression to conditionally get the bill id (if it exists)
        //        BillID = data.Taken ? //if data.Taken
        //                 data.CommonBilling.BillID //use the bill id if it is taken
        //                 : (int?) null, //otherwise, use this if taken is false
        //        BillTotal = data.Taken ? data.CommonBilling.BillTotal : (decimal?) null,
        //        Waiter = data.Taken ? data.CommonBilling.Waiter : (string) null,
        //        ReservationName = data.Taken ? 
        //                        (data.CommonBilling.Reservation != null ?
        //                            data.CommonBilling.Reservation.CustomerName :
        //                            (string) null)
        //                        : (string) null


    }
}
