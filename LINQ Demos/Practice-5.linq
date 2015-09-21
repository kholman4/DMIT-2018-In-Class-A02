<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from order in Bills
where order.OrderReady == null && order.OrderPlaced !=null
select new 
{
	BillID = order.BillID,
	TableID = order.TableID,
	BillItems = from item in order.BillItems
				select new 
				{
					ItemName = item.Item.Description,
					Quantity = item.Quantity,
					SalePrice = item.SalePrice,
					Total = item.Quantity * item.SalePrice
				}
				

}
