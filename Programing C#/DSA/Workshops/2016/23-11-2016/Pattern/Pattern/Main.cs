using System;

namespace Pattern
{
	class MainClass
	{
		public static void Main()
		{

			// Your solution goes here
			string figure = "urd";
			Console.WriteLine(figure);

			// comment before submitting
			Svg.WriteToFile("output.svg", figure);
		}
	}
}
