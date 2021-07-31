using System;
using C21_Ex02_Connect4Controller.Game.Engine;
using C21_Ex02_Connect4Framework.Controllers;
using C21_Ex02_Connect4View.Views;
using C21_Ex02_UserInputUtils;
using Ex02.ConsoleUtils;

namespace C21_Ex02_Connect4View.Menus
{
	internal class CreateNewGame
	{
		private const int k_MaximumLength = 8;
		private const int k_MinimumLength = 4;

		public bool ShowMenu(out IBoardGameEngine<eGameTool> o_GameEngine)
		{
			o_GameEngine = null;
			bool exit;

			Screen.Clear();

			string userInputRequestMessage = 
@"Create new Connect 4 Game
=========================

Welcome to Connect 4 Game.
You may enter Q to quit at any stage.
Please enter amount of rows: ";

			string userInput = ConsoleReader.ReadUserInputWithValidation(userInputRequestMessage, validateRowsAndColsInput);
			if (userInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				exit = true;
			}
			else
			{
				int rows = int.Parse(userInput);
				userInput = ConsoleReader.ReadUserInputWithValidation("Please enter amount of columns: ", validateRowsAndColsInput);
				if (userInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase))
				{
					exit = true;
				}
				else
				{
					int columns = int.Parse(userInput);
					o_GameEngine = GameController.Instance.NewConnect4GameEngine<eGameTool>(rows, columns);
					exit = new CreatePlayers().ShowMenu(o_GameEngine);
				}
			}

			return exit;
		}

		private bool validateRowsAndColsInput(string i_UserInput)
		{
			int length;
			return i_UserInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				   (int.TryParse(i_UserInput, out length) && (length >= k_MinimumLength) && (length <= k_MaximumLength));
		}
	}
}