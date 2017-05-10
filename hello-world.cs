using System;

namespace hello.world
{
	public static class Program
	{
		public static void Main(string[] arguments)
		{
			Console.WriteLine("Hello World!");
			
			int[] numbers = {4, 7, 11, 19, 23, 28, 31};
			
			foreach (int number in numbers)
			{
				Console.WriteLine(number.ToString());
			}
		}
	}
}
