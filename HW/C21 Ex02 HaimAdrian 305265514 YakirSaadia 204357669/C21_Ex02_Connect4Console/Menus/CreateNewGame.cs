using System;
using C21_Ex02_Connect4Console.Views;
using C21_Ex02_Connect4Engine.Api.Game.Engine;
using C21_Ex02_Connect4Engine.Api.Controller;
using C21_Ex02_UserInputUtils;
using Ex02.ConsoleUtils;

namespace C21_Ex02_Connect4Console.Menus
{
	internal class CreateNewGame
	{
		private const int k_MaximumLength = 8;
		private const int k_MinimumLength = 4;

		private static bool validateRowsAndColsInput(string i_UserInput)
		{
			int length;
			return i_UserInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				   (int.TryParse(i_UserInput, out length) && (length >= k_MinimumLength) && (length <= k_MaximumLength));
		}

		public bool ShowMenu(out IBoardGameEngine<eGameTool> o_GameEngine)
		{
			o_GameEngine = null;
			bool exit;

			Screen.Clear();

			const string v_UserInputRequestMessage = 
@"Create new Connect 4 Game
=========================

Welcome to Connect 4 Game.
You may enter Q to quit at any stage.
Undo/Redo: Enter Z to undo last move and R to redo last undone move.

Please enter amount of rows: ";

			string userInput = ConsoleReader.ReadUserInputWithValidation(v_UserInputRequestMessage, validateRowsAndColsInput);
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
	}
}