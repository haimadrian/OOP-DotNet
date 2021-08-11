using System;

namespace Ex04.ConsoleMenu
{
	public static class ConsoleReader
	{
		public static string ReadUserInputWithValidation(string i_UserInputRequestMessage, UserInputValidationDelegate i_IsInputValidFunc)
		{
			string userInput;

			if (!string.IsNullOrEmpty(i_UserInputRequestMessage))
			{
				Console.Write(i_UserInputRequestMessage);
			}

			while (!i_IsInputValidFunc(userInput = Console.ReadLine()))
			{
				Console.Write("Illegal input. Try again: ");
			}

			return userInput;
		}
	}
}