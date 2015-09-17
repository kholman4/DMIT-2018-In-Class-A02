<Query Kind="Program">
  <Connection>
    <ID>8624f282-54e6-4a60-ae4b-a1735ce5dcd1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//C# Primer on nullable types 
void Main()
{
	int? totalCount = 5;
	totalCount.Dump();
	
	if(totalCount.HasValue) //HasValue is false if there is no int value
	{
		"It has a value".Dump();
	}
	else
	{
		"It does not have a value - it is null.".Dump();
	}
}

// Define other methods and classes here
