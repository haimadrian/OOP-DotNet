using System;
using System.Collections.Generic;
using C21_Ex02_Connect4Engine.Api.Game.Board;
using C21_Ex02_Connect4Engine.Api.Game.Engine;
using C21_Ex02_Connect4Engine.Api.Game.Player;
using C21_Ex02_Connect4Engine.Api.Matrix;

namespace C21_Ex02_Connect4Engine.Core.Game.Player
{
	internal class BotRandom<T> : Player<T>, IBot<T>
	{
		private const int k_TopAvailabilityRow = 0;
		private const string k_PlayerName = "Noob";
		private readonly Random r_Random;

		public BotRandom() : base(k_PlayerName, k_PlayerName)
		{
			r_Random = new Random();
		}

		private static IList<int> collectColumnsHavingRoom(IBoard<T> i_Board)
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

		private Random Rand
		{
			get
			{
				return r_Random;
			}
		}

		public Index MakeMove(IBoardGameEngine<T> i_GameEngine)
		{
			IList<int> availableColumns = collectColumnsHavingRoom(i_GameEngine.Board);
			int randomColumnIndex = Rand.Next(availableColumns.Count);

			return i_GameEngine.MakePlayerMove(this, availableColumns[randomColumnIndex]);
		}
	}
}
