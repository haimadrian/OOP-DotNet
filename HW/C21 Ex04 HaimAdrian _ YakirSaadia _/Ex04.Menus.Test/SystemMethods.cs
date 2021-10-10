using System;

namespace Ex04.Menus.Test
{
	internal static class SystemMethods
	{
		public static void ShowVersion()
		{
			Console.WriteLine("Version: 21.3.4.8933");
			DoPressEnterToContinue();
		}

		public static void CountSpaces()
		{
			Console.WriteLine("Please enter a sentence:");
			string userInput = Console.ReadLine();

			int spacesCount = 0;

			if (userInput != null)
			{
				foreach (char currentChar in userInput)
				{
					if (char.IsWhiteSpace(currentChar))
					{
						spacesCount++;
					}
				}
			}

			Console.WriteLine("Amount of whitespace characters in your sentence is: {0}", spacesCount);
			DoPressEnterToContinue();
		}

		public static void ShowDate()
		{
			Console.WriteLine(DateTime.Now.ToShortDateString());
			DoPressEnterToContinue();
		}

		public static void ShowTime()
		{
			Console.WriteLine(DateTime.Now.ToShortTimeString());
			DoPressEnterToContinue();
		}

		public static void DoPressEnterToContinue()
		{
			Console.WriteLine("{0}Press Enter to continue...", Environment.NewLine);
			Console.ReadLine();
		}
	}
}