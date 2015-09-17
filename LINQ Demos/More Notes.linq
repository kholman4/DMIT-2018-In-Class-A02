<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

(
from customer in Bills
where customer.ReservationID.HasValue
   && customer.PaidStatus == true
   && customer.BillDate.Year == 2014
   && customer.BillDate.Month == 10
   && customer.BillDate.Day > 23
select new
{
   BillId = customer.BillID,
   Total = customer.BillItems.Sum(item => item.Quantity * item.SalePrice),
   Type = "Reservation"
}
).Union(
from customer in Bills
where customer.TableID.HasValue
   && customer.PaidStatus == true
   && customer.BillDate.Year == 2014
   && customer.BillDate.Month == 10
   && customer.BillDate.Day > 22
select new
{
   BillId = customer.BillID,
   Total = customer.BillItems.Sum(item => item.Quantity * item.SalePrice),
   Type = "Walk-In"
}
)