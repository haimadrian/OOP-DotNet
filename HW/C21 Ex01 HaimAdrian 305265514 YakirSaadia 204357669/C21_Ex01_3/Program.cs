using System;
using C21_Ex01_UserInputUtils;

namespace C21_Ex01_3
{
	public class Program
	{
		public static void Main()
		{
			RunSandMachine();
			Console.WriteLine("Please press 'Enter' to exit...");
			Console.ReadLine();
		}

		public static void RunSandMachine()
		{
			int numOfLines = readNaturalIntFromConsole();

			// Zero means DO NOTHING
			if (numOfLines > 0)
			{
				if (numOfLines % 2 == 0)
				{
					numOfLines++;
				}
				
				C21_Ex01_2.Program.DrawSandMachine(numOfLines);
			}
		}

		private static int readNaturalIntFromConsole()
		{
			string userInputRequestMessage = "Please enter the number of lines for the sand machine: ";
			string userInput = ConsoleReader.ReadUserInputWithValidation(userInputRequestMessage, isNaturalNumber);
			return int.Parse(userInput);
		}

		private static bool isNaturalNumber(string i_UserInput)
		{
			int input;
			return int.TryParse(i_UserInput, out input) && (input >= 0);
		}
	}
}