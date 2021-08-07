using System;
using Ex03.ConsoleUI.App;

namespace Ex03.ConsoleUI
{
	public class Program
	{
		public static void Main()
		{
			try
			{
				GarageApplication application = new GarageApplication();
				application.Run();
			}
			catch (Exception e)
			{
				Console.WriteLine("Unexpected error has occurred: {0}", e);
			}

			Console.WriteLine("{0}Press Enter to exit...", Environment.NewLine);
			Console.ReadLine();
		}
	}
}