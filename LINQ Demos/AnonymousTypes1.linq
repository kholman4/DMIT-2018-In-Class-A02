<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//AnonymousTypes1

from food in Items
where food.MenuCategory.Description == "Entree" && food.Active 
orderby food.CurrentPrice descending
select new
{
	Description = food.Description,
	Price = food.CurrentPrice,
	Calories = food.Calories
}

//selects all the entrees in the table that are active and only displays the data included in the new anonymous data type
//select new creates a new "anonymous" data type that contains all the data included