<Query Kind="Statements">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Find out information on the tables in the restaurant at a specific date/time
//Create a date and time object to use for sample input data

var date = Bills.Max(b => b.BillDate).Date; //just want the date portion
var time = Bills.Max(b => b.BillDate).TimeOfDay.Add(new TimeSpan(0, 30, 0));
date.Add(time).Dump("The test date/time I am using");

//Step 1 - Get the table info along with any walk-in bills and reservation bills for a specific time slot

var step1 = from data in Tables
			select new 
			{
				Table = data.TableNumber,
				Capacity = data.Capacity,
				
				//This sub-query gets the bills for walk-in customers
				WalkIns = from walkin in data.Bills
							where walkin.BillDate.Year == date.Year
							&& walkin.BillDate.Month == date.Month
							&& walkin.BillDate.Day == date.Day
							&& (!walkin.OrderPlaced.HasValue || walkin.OrderPaid.Value >= time) //order paid is null OR order paid value is greater than current time
						select walkin,
				//This subquery gets the bills for reservations
				Reservations = from booking in data.ReservationTables
							   from reservationParty in booking.Reservation.Bills
							   where reservationParty.BillDate.Year == date.Year
							   && reservationParty.BillDate.Month == date.Month
							   && reservationParty.BillDate.Day == date.Day
							   && (!reservationParty.OrderPaid.HasValue || reservationParty.OrderPaid >= time)
							   select reservationParty
			};
step1.Dump("Results of step 1");


//Step 2 - Union the walk-in bills with the reservation bills while extracting the relevant bill info
// 			.ToList() helps resolve the error "Types in Union or Concat are constructed incompatibly"
//the union will work because WalkIns and Reservations are formatted the same (they are essentially BIll Objects)

var step2 = from data in step1.ToList() //this will force step1 into RAM
			select new
			{
				Table = data.Table,
				Capacity = data.Capacity,
				CommonBilling = from info in data.WalkIns.Union(data.Reservations)
								select new //trimmed down billing information
								{
									BillID = info.BillID,
									BillTotal = info.BillItems.Sum(bi => bi.Quantity * bi.SalePrice),
                                    Waiter = info.Waiter.FirstName,
                                    Reservation = info.Reservation
								}
			};
step2.Dump("Results of step 2");

//Step 3 - Get just the first CommonBilling item
//			(assuming no overlaps can occur - i.e. two groups at the same table at the same time)
//*changes it from being a list into an actual object

var step3 = from data in step2.ToList()
			select new
			{
				Table = data.Table,
				Capacity = data.Capacity,
				Taken = data.CommonBilling.Count() > 0,
				//FirstOrDefault() is effectively "flattening" my collection of 1 item into a single
				//object whose properties I can get in Step 4 using the dot (.) operator
				CommonBilling = data.CommonBilling.FirstOrDefault()
			};
step3.Dump("Results of step 3");



//Step 4 - Build our intended seating summary info

var step4 = from data in step3
			select new //SeatingSummary() the DTO class to use in my BLL
			{
				Table = data.Table,
				Capacity = data.Capacity,
				Taken = data.Taken,
				//use a ternary expression to conditionally get the bill id (if it exists)
				BillID = data.Taken ? //if data.Taken
						 data.CommonBilling.BillID //use the bill id if it is taken
						 : (int?) null, //otherwise, use this if taken is false
				BillTotal = data.Taken ? data.CommonBilling.BillTotal : (decimal?) null,
				Waiter = data.Taken ? data.CommonBilling.Waiter : (string) null,
				ReservationName = data.Taken ? 
								(data.CommonBilling.Reservation != null ?
								  	data.CommonBilling.Reservation.CustomerName :
									(string) null)
								: (string) null
			};
step4.Dump("Results of step 4");









