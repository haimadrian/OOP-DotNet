using System;

namespace C21_Ex02_Connect4Console
{
	public class Program
	{
		public static void Main()
		{
			try
			{
				ConnectFourApplication application = new ConnectFourApplication();
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
