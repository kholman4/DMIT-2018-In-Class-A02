<Query Kind="Expression">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//AnonymousTypes2

from person in Waiters
where person.ReleaseDate == null //people who are still employed
select new
{
	Name = person.FirstName + " " + person.LastName,
	Phone = person.Phone,
	DaysEmployed = (DateTime.Today - person.HireDate).Days
}

//selects all current employees and displays the amount of days employed