<Query Kind="Expression">
  <Connection>
    <ID>4688dd52-597e-4a50-9445-068a55a8744a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from booking in Reservations
where booking.EventCode.Equals("A")
select booking
//booking is a variable name that can be changed as needed