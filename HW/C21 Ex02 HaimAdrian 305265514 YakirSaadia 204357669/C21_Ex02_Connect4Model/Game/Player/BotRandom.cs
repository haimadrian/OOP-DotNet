using System;
using System.Collections.Generic;
using C21_Ex02_Connect4Controller.Game.Board;
using C21_Ex02_Connect4Controller.Game.Engine;
using C21_Ex02_Connect4Controller.Game.Player;
using C21_Ex02_Connect4Controller.Matrix;

namespace C21_Ex02_Connect4Model.Game.Player
{
	public class BotRandom<T> : Player<T>, IBot<T>
	{
		private const int k_TopAvailabilityRow = 0;
		private const string k_PlayerName = "Noob";
		private readonly Random r_Random;

		public BotRandom() : base(k_PlayerName, k_PlayerName)
		{
			r_Random = new Random();
		}

		private Random Rand
		{
			get
			{
				return r_Random;
			}
		}

		public Index MakeMove(IBoardGameEngine<T> i_GameEngine, out ICollection<Index> o_GameToolsInARow)
		{
			IList<int> availableColumns = collectColumnsHavingRoom(i_GameEngine.Board);
			int randomColumnIndex = Rand.Next(availableColumns.Count);

			return i_GameEngine.MakePlayerMove(this, availableColumns[randomColumnIndex], out o_GameToolsInARow);
		}

		private IList<int> collectColumnsHavingRoom(IBoard<T> i_Board)
		{
			IList<int> availableColumns = new List<int>(i_Board.Columns);

			for (int currentColumn = 0; currentColumn < i_Board.Columns; currentColumn++)
			{
				if (i_Board.IsCellHavingRoom(k_TopAvailabilityRow, currentColumn))
				{
					availableColumns.Add(currentColumn);
				}
			}

			return availableColumns;
		}
	}
}