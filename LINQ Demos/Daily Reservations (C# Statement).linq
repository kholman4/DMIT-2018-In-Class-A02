<Query Kind="Statements">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//from eachRow in Reservations
//where eachRow.ReservationStatus == 'B'
//orderby eachRow.ReservationDate
//group eachRow by new { eachRow.ReservationDate.Month, eachRow.ReservationDate.Day }

var step1 = from eachRow in Reservations
where eachRow.ReservationStatus == 'B'
	//TBA - && eachRow has the correct event code  (&& eachRow.EventCode == 'S')
orderby eachRow.ReservationDate
group eachRow by new { eachRow.ReservationDate.Month, eachRow.ReservationDate.Day }; //start the code from beginning up until this point will give you all the details of the reservations

var result = from dailyReservation in step1.ToList()
select new { //DailyReservation() //Create a DTO class called DailyReservation
	Month = dailyReservation.Key.Month,
	Day = dailyReservation.Key.Day,
	Reservations = from booking in dailyReservation
					select new{ //Booking() //Create a Booking POCO class
						Name = booking.CustomerName,
						NumberInParty = booking.NumberInParty,						
						Time = booking.ReservationDate.TimeOfDay,
						Phone = booking.ContactPhone, 
						Event = booking.SpecialEvents == null 
								?(string)null : booking.SpecialEvents.Description //if the string is null, then put "null" as the description
					}
};
result.Dump();