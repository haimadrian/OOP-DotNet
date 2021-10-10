using System;
using System.Collections.Generic;
using C21_Ex02_Connect4Engine.Api.Game.Engine;
using C21_Ex02_Connect4Engine.Api.Game.Exceptions;
using C21_Ex02_Connect4Engine.Api.Game.Player;
using C21_Ex02_Connect4Engine.Api.Matrix;
using C21_Ex02_UserInputUtils;
using Ex02.ConsoleUtils;

namespace C21_Ex02_Connect4Console.Views
{
	internal class GameManager
	{
		private const int k_MinimumColumnNumber = 1;
		private const int k_AmountOfGameToolsInARowToWin = 4;

		private readonly IBoardGameEngine<eGameTool> r_GameEngine;
		private readonly BoardView r_BoardView;

		private ICollection<Index> m_WinningFourInARow;

		public GameManager(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			r_GameEngine = i_GameEngine;
			r_BoardView = new BoardView(r_GameEngine.Board);
		}

		private static bool restartInputValidation(string i_UserInput)
		{
			return quitUndoInputValidation(i_UserInput) ||
				   i_UserInput.Equals(eKeys.Y.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				   i_UserInput.Equals(eKeys.N.ToString(), StringComparison.InvariantCultureIgnoreCase);
		}

		private static bool quitUndoInputValidation(string i_UserInput)
		{
			return i_UserInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				   i_UserInput.Equals(eKeys.Z.ToString(), StringComparison.InvariantCultureIgnoreCase);
		}

		private static bool quitUndoRedoInputValidation(string i_UserInput)
		{
			return quitUndoInputValidation(i_UserInput) || i_UserInput.Equals(eKeys.R.ToString(), StringComparison.InvariantCultureIgnoreCase);
		}

		private IBoardGameEngine<eGameTool> GameEngine
		{
			get
			{
				return r_GameEngine;
			}
		}

		private BoardView BoardView
		{
			get
			{
				return r_BoardView;
			}
		}

		public void StartGame()
		{
			GameEngine.Start();
		}

		public bool Refresh()
		{
			bool exit;

			drawBoard();

			if (GameEngine.Board.IsBoardFull && ((m_WinningFourInARow == null) || (m_WinningFourInARow.Count != k_AmountOfGameToolsInARowToWin)))
			{
				exit = handleDraw();
			}
			else if ((m_WinningFourInARow != null) && (m_WinningFourInARow.Count == k_AmountOfGameToolsInARowToWin))
			{
				exit = handleWinner();
			}
			else
			{
				exit = handleCurrentPlayerMove();
			}

			return exit;
		}

		private void drawBoard()
		{
			// Check if there is a winner, and fill in the 4 tools, or latest tool, so we will mark them.
			GameEngine.HasWinner(out m_WinningFourInARow);

			Screen.Clear();
			BoardView.Refresh(m_WinningFourInARow);
		}

		private bool handleWinner()
		{
			IPlayer<eGameTool> winner = GameEngine.LastActivePlayer;
			IPlayer<eGameTool> loser = GameEngine.ActivePlayer;

			winner.Score++;

			Console.WriteLine("{0} ({1}) Won!", winner.Name, winner.GameTool);
			return showStatisticsAndAskForRestart(winner, loser);
		}

		private bool handleDraw()
		{
			Console.WriteLine("It's a draw.");
			return showStatisticsAndAskForRestart(GameEngine.ActivePlayer, GameEngine.LastActivePlayer);
		}

		private bool showStatisticsAndAskForRestart(IPlayer<eGameTool> i_Player1, IPlayer<eGameTool> i_Player2)
		{
			bool exit = false;

			string userInputMessage = string.Format(
@"
Score:
======
{0} ({1}): {4}
{2} ({3}): {5}
Would you like to restart? (y to restart, n/q to quit, z to undo)
",
				i_Player1.Name,
				i_Player1.GameTool,
				i_Player2.Name,
				i_Player2.GameTool,
				i_Player1.Score,
				i_Player2.Score);
			string userInput = ConsoleReader.ReadUserInputWithValidation(userInputMessage, restartInputValidation);

			if (userInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				userInput.Equals(eKeys.N.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				exit = true;
			}
			else if (userInput.Equals(eKeys.Z.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				handleUndo();
			}
			else
			{
				GameEngine.Restart();

				if (m_WinningFourInARow != null)
				{
					m_WinningFourInARow.Clear();
				}
			}

			return exit;
		}

		private bool handleCurrentPlayerMove()
		{
			bool exit = false;
			Console.WriteLine("{0}'s Turn.", GameEngine.ActivePlayer.Name);

			// Bots play automatically, so avoid of input request.
			if (!(GameEngine.ActivePlayer is IBot<eGameTool>))
			{
				bool successfulMove;
				do
				{
					string userInputMessage = string.Format(
						"Which column would you like to play at? [{0}, {1}]: ",
						k_MinimumColumnNumber,
						GameEngine.Board.Columns);
					string userInput = ConsoleReader.ReadUserInputWithValidation(userInputMessage, columnRangeInputValidation);

					if (!handleQuitOrUndoOrRedo(userInput, out exit, out successfulMove))
					{
						successfulMove = handlePlayerMove(userInput);
					}
				}
				while (!exit && !successfulMove);
			}
			else if (GameEngine.CanRedo)
			{
				// If we can redo, it means player did undo. Let player decide if he's like to continue undoing/redoing
				string userInput = ConsoleReader.ReadUserInputWithValidation("Enter Z to undo or R to redo: ", quitUndoRedoInputValidation);
				bool ignore;
				handleQuitOrUndoOrRedo(userInput, out exit, out ignore);
			}
			else
			{
				Index ignore;
				GameEngine.OptionallyPlayPcMove(out ignore);
			}

			return exit;
		}

		private bool handleQuitOrUndoOrRedo(string i_UserInput, out bool o_Exit, out bool o_SuccessfulMove)
		{
			bool handled = true;
			o_Exit = false;
			o_SuccessfulMove = false;

			if (i_UserInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				o_Exit = true;
			}
			else if (i_UserInput.Equals(eKeys.Z.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				o_SuccessfulMove = handleUndo();
			}
			else if (i_UserInput.Equals(eKeys.R.ToString(), StringComparison.InvariantCultureIgnoreCase))
			{
				o_SuccessfulMove = handleRedo();
			}
			else
			{
				handled = false;
			}

			return handled;
		}

		private bool handlePlayerMove(string i_UserInput)
		{
			bool successfulMove = false;

			try
			{
				int columnNumber = int.Parse(i_UserInput);
				GameEngine.MakePlayerMove(GameEngine.ActivePlayer, columnNumber - k_MinimumColumnNumber);
				successfulMove = true;
			}
			catch (IllegalPlayerMoveException e)
			{
				Console.WriteLine("{0} Please select another column.", e.Message);
			}

			return successfulMove;
		}

		private bool handleUndo()
		{
			bool undone = GameEngine.UndoLastMove();

			if (!undone)
			{
				Console.WriteLine("Nothing to undo.");
			}

			return undone;
		}

		private bool handleRedo()
		{
			bool redone = GameEngine.RedoLastMove();

			if (!redone)
			{
				Console.WriteLine("Nothing to redo.");
			}

			return redone;
		}

		private bool columnRangeInputValidation(string i_UserInput)
		{
			int columnNumber;
			return quitUndoRedoInputValidation(i_UserInput) ||
				   (int.TryParse(i_UserInput, out columnNumber) && (columnNumber >= k_MinimumColumnNumber) && (columnNumber <= GameEngine.Board.Columns));
		}
	}
}