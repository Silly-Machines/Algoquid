using System;
using System.Text;

public class RandomStringGenerator
{
	public const string ALPHANUMERIC_CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
	public const string ALPHA_CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	public const string NUMERIC = "1234567890";
	
	Random rand = new Random();
	public string GetRandomString(int length, params char[] chars)
	{
		StringBuilder builder = new StringBuilder();
		char ch;
		for (int i = 0; i < length; i++)
		{
			ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));                 
			builder.Append(ch);
		}
		
		return builder.ToString();
	}
}
