<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from cat in MenuCategories
orderby cat.Description
select new
{
	Description = cat.Description,
	MenuItems = from item in cat.Items
				where item.Active
				orderby item.Description
				select new
				{	
					Description = item.Description,
					Price = item.CurrentPrice, 
					Calories = item.Calories,
					Comment = item.Comment
				}
}