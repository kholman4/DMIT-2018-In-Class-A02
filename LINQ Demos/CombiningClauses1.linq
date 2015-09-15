<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//CombiningClauses1

from food in Items 
where food.MenuCategory.Description == "Entree"
orderby food.CurrentPrice descending
select food

//List all the menu items that are Entrees in order from most to least expensive
//When looking at the SQL code, you can see that there is an inner join to grab the "Entree" description
//"WHERE" and "ORDERBY" can be reversed and still return the same values
//FROM starts, SELECT ends