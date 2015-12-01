<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Select the bill items for a specific bill (in this case, the unpaid bill)
from data in Bills
where data.BillID == 10975 //this would be billID that they ask for when wanting to split
select new // Order()
{
	BillID = data.BillID,
	Items = (from info in data.BillItems
			select new //OrderItem()
			{
				ItemName = info.Item.Description,
				Price = info.SalePrice,
				Quantity = info.Quantity				
			}).ToList()
}