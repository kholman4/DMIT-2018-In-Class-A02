<Query Kind="Program" />

//C# Primer on extension methods

void Main()
{
	string name = "Dan";
	string message = name.Sleepy(); //.Sleepy is an extension method
	message.Dump(); //.Dump is an extension method
	
	message = name.Sleepy(3);
	message.Dump();
}

// Define other methods and classes here

public static class StringExtensions
{
	public static string Sleepy(this string text) //this string is the data type you are adding on
	{
		return text + " - Yawn, are we there yet?";
	}
	
	public static string Sleepy(this string text, int count)
	{
		string tired = "Yawn";
		
		while(count > 0)
		{
			text = text + " - " + tired;
			count--;
		}
		return text + "! Are we there yet?";
	}
}