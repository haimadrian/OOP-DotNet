using System;
using Ex03.ConsoleUI.App.Menus;
using Ex03.ConsoleUI.App.Utils;
using Ex03.UserInputUtils;

namespace Ex03.ConsoleUI.App
{
	internal class GarageApplication
	{
		private static bool isInputValidFunc(string i_InputString)
		{
			return string.IsNullOrEmpty(i_InputString) || eKeys.Q.ToString().Equals(i_InputString, StringComparison.InvariantCultureIgnoreCase);
		}

		public void Run()
		{
			try
			{
				new MainMenu().Show();
			}
			catch (Exception e)
			{
				Console.WriteLine("Unexpected error has occurred: {0}{1}To go back, press enter. To quit, enter q.", e, Environment.NewLine);
				string userInput = ConsoleReader.ReadUserInputWithValidation(string.Empty, isInputValidFunc);

				// Check if user selected to go back to main menu.
				if (string.IsNullOrEmpty(userInput))
				{
					Run();
				}
			}
		}
	}
}
