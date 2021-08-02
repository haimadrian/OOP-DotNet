using System;
using System.Text;
using C21_Ex02_Connect4Console.Views;
using C21_Ex02_Connect4Engine.Api.Game.Engine;
using C21_Ex02_Connect4Engine.Api.Game.Exceptions;
using C21_Ex02_Connect4Engine.Api.Game.Player;
using C21_Ex02_Connect4Engine.Api.Controller;
using C21_Ex02_UserInputUtils;
using Ex02.ConsoleUtils;

namespace C21_Ex02_Connect4Console.Menus
{
	internal class CreatePlayers
	{
		private const int k_MaximumUserNameLength = 26;
		private const int k_AmountOfPlayers = 2;
		
		// Initialized lazily, only if necessary (Multi-Player)
		private Random m_RandForMultiPlayer;

		private static bool validateGameModeUserSelection(string i_UserInput)
		{
			int userChoice;
			return i_UserInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				   (int.TryParse(i_UserInput, out userChoice) &&
					(userChoice >= (int)eCreatePlayersMenuItem.MultiPlayer) &&
					(userChoice <= (int)eCreatePlayersMenuItem.Pc));
		}

		private static bool validateUserName(string i_UserInput)
		{
			return i_UserInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase) || (i_UserInput.Length < k_MaximumUserNameLength);
		}

		private static bool validateAiLevelUserSelection(string i_UserInput)
		{
			int userChoice;
			return i_UserInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				   (int.TryParse(i_UserInput, out userChoice) && (userChoice >= (int)eAiLevel.Newbie) && (userChoice <= (int)eAiLevel.Expert));
		}

		private static bool handlePcSelection(out IPlayer<eGameTool> o_PcPlayer)
		{
			bool exit = false;

			StringBuilder userInputRequestMessage = new StringBuilder("Please select AI level:").AppendLine();
			foreach (eAiLevel currentAiLevel in Enum.GetValues(typeof(eAiLevel)))
			{
				if (currentAiLevel > eAiLevel.None)
				{
					userInputRequestMessage.Append((int)currentAiLevel).Append(". ").AppendLine(currentAiLevel.ToString());
				}
			}

			string userInput = ConsoleReader.ReadUserInputWithValidation(userInputRequestMessage.ToString(), validateAiLevelUserSelection);
			if (userInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				exit = true;
				o_PcPlayer = null;
			}
			else
			{
				eAiLevel selectedAiLevel = (eAiLevel)Enum.GetValues(typeof(eAiLevel)).GetValue(int.Parse(userInput));
				o_PcPlayer = PlayerController.Instance.NewBot<eGameTool>(selectedAiLevel);
			}

			return exit;
		}

		public bool ShowMenu(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			bool exit;
			Screen.Clear();

			const string v_UserInputRequestMessage = 
@"Who plays Connect 4 Game?
=========================

Please select game mode:
1. Multi-Player
2. PC
Q. Quit
";

			string userInput = ConsoleReader.ReadUserInputWithValidation(v_UserInputRequestMessage, validateGameModeUserSelection);
			if (userInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				exit = true;
			}
			else
			{
				eCreatePlayersMenuItem selectedMenuItem = (eCreatePlayersMenuItem)Enum.GetValues(typeof(eCreatePlayersMenuItem)).GetValue(int.Parse(userInput));
				exit = createPlayers(selectedMenuItem, i_GameEngine);
			}

			return exit;
		}

		private bool createPlayers(eCreatePlayersMenuItem i_SelectedMenuItem, IBoardGameEngine<eGameTool> i_GameEngine)
		{
			bool exit;

			string userInput = ConsoleReader.ReadUserInputWithValidation(
				string.Format("Please enter your name (up to {0} characters): ", k_MaximumUserNameLength),
				validateUserName);
			if (userInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				exit = true;
			}
			else
			{
				IPlayer<eGameTool> firstPlayer = PlayerController.Instance.NewPlayer<eGameTool>(userInput, userInput);
				IPlayer<eGameTool> secondPlayer = null;

				switch (i_SelectedMenuItem)
				{
					case eCreatePlayersMenuItem.MultiPlayer:
						exit = handleMultiPlayerSelection(i_GameEngine, ref firstPlayer, out secondPlayer);
						break;
					case eCreatePlayersMenuItem.Pc:
						exit = handlePcSelection(out secondPlayer);
						break;
					case eCreatePlayersMenuItem.Quit:
						exit = true;
						break;
					default:
						throw new GameEngineException(string.Format("Game mode can be Multi-Player or PC only. Was: {0}", i_SelectedMenuItem.ToString()));
				}

				if (!exit)
				{
					firstPlayer.GameTool = eGameTool.O;
					secondPlayer.GameTool = eGameTool.X;

					i_GameEngine.AddPlayer(firstPlayer);
					i_GameEngine.AddPlayer(secondPlayer);
				}
			}

			return exit;
		}

		private bool handleMultiPlayerSelection(
			IBoardGameEngine<eGameTool> i_GameEngine,
			ref IPlayer<eGameTool> io_FirstPlayer,
			out IPlayer<eGameTool> o_SecondPlayer)
		{
			bool exit = false;

			string userInput = ConsoleReader.ReadUserInputWithValidation(
				string.Format("Please enter second player name (up to {0} characters): ", k_MaximumUserNameLength),
				validateUserName);

			if (userInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				o_SecondPlayer = null;
				exit = true;
			}
			else
			{
				o_SecondPlayer = PlayerController.Instance.NewPlayer<eGameTool>(userInput, userInput);

				if (m_RandForMultiPlayer == null)
				{
					m_RandForMultiPlayer = new Random();
				}

				// Use it like a NextBoolean().
				// When we get 1, swap players. (Randomly choosing who starts)
				if (m_RandForMultiPlayer.Next(k_AmountOfPlayers) > 0)
				{
					IPlayer<eGameTool> tempPlayer = io_FirstPlayer;
					io_FirstPlayer = o_SecondPlayer;
					o_SecondPlayer = tempPlayer;
				}

				i_GameEngine.ActivePlayer = io_FirstPlayer;
			}

			return exit;
		}

		private enum eCreatePlayersMenuItem
		{
			Quit,
			MultiPlayer,
			Pc
		}
	}
}