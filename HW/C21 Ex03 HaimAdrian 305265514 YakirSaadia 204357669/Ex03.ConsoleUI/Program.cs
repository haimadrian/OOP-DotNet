using System;
using Ex03.ConsoleUI.App;

namespace Ex03.ConsoleUI
{
	public class Program
	{
		public static void Main()
		{
			GarageApplication application = new GarageApplication();
			application.Run();

			Console.WriteLine("{0}Press Enter to exit...", Environment.NewLine);
			Console.ReadLine();
		}
	}
}