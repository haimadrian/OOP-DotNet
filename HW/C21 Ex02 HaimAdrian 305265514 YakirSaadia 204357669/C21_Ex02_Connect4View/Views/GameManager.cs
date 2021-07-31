using System;
using System.Collections.Generic;
using C21_Ex02_Connect4Controller.Collections;
using C21_Ex02_Connect4Controller.Game.Engine;
using C21_Ex02_Connect4Controller.Game.Player;
using C21_Ex02_Connect4Controller.Matrix;
using C21_Ex02_UserInputUtils;
using Ex02.ConsoleUtils;

namespace C21_Ex02_Connect4View.Views
{
	internal class GameManager
	{
		private const int k_MinimumColumnNumber = 1;
		private const int k_AmountOfGameToolsInARowToWin = 4;

		private readonly IBoardGameEngine<eGameTool> r_GameEngine;
		private readonly BoardView r_BoardView;

		private ICollection<Index> m_WinningFourInARow;
		private Index m_LastMove;

		public GameManager(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			r_GameEngine = i_GameEngine;
			r_BoardView = new BoardView(r_GameEngine.Board);
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
			if (m_WinningFourInARow == null)
			{
				m_WinningFourInARow = new HashSet<Index>(1);
			}

			if (m_WinningFourInARow.Count != k_AmountOfGameToolsInARowToWin)
			{
				m_WinningFourInARow.Clear();

				if (m_LastMove != default(Index))
				{
					m_WinningFourInARow.Add(m_LastMove);
				}
			}
			else
			{
				// When there is a win, clear last move cause we highlight the four winning game tools already.
				m_LastMove = default(Index);
			}

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
Would you like to restart? (y to restart, n/q to quit)
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
				bool successfulMove = false;
				do
				{
					string userInputMessage = string.Format(
						"Which column would you like to play at? [{0}, {1}]: ",
						k_MinimumColumnNumber,
						GameEngine.Board.Columns);
					string userInput = ConsoleReader.ReadUserInputWithValidation(userInputMessage, columnRangeInputValidation);

					if (userInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase))
					{
						exit = true;
					}
					else
					{
						int columnNumber = int.Parse(userInput);
						successfulMove = GameEngine.TryMakePlayerMove(
							GameEngine.ActivePlayer,
							columnNumber - k_MinimumColumnNumber,
							out m_WinningFourInARow,
							out m_LastMove);

						if (!successfulMove)
						{
							Console.WriteLine("Column {0} is full. Please select another column.", columnNumber);
						}
					}
				}
				while (!exit && !successfulMove);
			}
			else
			{
				GameEngine.OptionallyPlayPcMove(out m_WinningFourInARow, out m_LastMove);
			}

			return exit;
		}

		private bool columnRangeInputValidation(string i_UserInput)
		{
			int columnNumber;
			return i_UserInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				   (int.TryParse(i_UserInput, out columnNumber) && (columnNumber >= k_MinimumColumnNumber) && (columnNumber <= GameEngine.Board.Columns));
		}

		private bool restartInputValidation(string i_UserInput)
		{
			return i_UserInput.Equals(eKeys.Q.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				   i_UserInput.Equals(eKeys.Y.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
				   i_UserInput.Equals(eKeys.N.ToString(), StringComparison.InvariantCultureIgnoreCase);
		}
	}
}