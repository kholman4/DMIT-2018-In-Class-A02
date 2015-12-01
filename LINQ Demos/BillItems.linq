<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//What bills are not yet paid?

from data in Bills
where !data.PaidStatus
	&& data.BillItems.Count()>0
select new //UnpaidBill()
{
	DisplayText = "Bill " + data.BillID.ToString(),
	KeyValue = data.BillID,
	Total = data.BillItems.Sum(bi => bi.SalePrice * bi.Quantity),
	Table = data.Table,
	Reservation = data.Reservation //If there is null for Table and information for Reservation, then it is a reservation and not a walkin 
}