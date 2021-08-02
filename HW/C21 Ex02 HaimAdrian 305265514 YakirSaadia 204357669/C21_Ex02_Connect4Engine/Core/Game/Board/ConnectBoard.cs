using System.Collections.Generic;
using C21_Ex02_Connect4Engine.Api.Collections;
using C21_Ex02_Connect4Engine.Api.Game.Exceptions;
using C21_Ex02_Connect4Engine.Api.Matrix;

namespace C21_Ex02_Connect4Engine.Core.Game.Board
{
	internal class ConnectBoard<T> : ABoard<T>
	{
		// A row we depend on to know if player can make a move in some column or not
		private const int k_TopAvailabilityRow = 0;
		private readonly int r_HowManyToolsToConnectInARow;

		public ConnectBoard(int i_Rows, int i_Columns, int i_HowManyToolsToConnectInARow) : base(i_Rows, i_Columns)
		{
			if ((i_HowManyToolsToConnectInARow > i_Rows) && (i_HowManyToolsToConnectInARow > i_Columns))
			{
				throw new IllegalConnectBoardException(
					string.Format(
						"Game board cannot have {0} game tools in a row. Size of board was {1}x{2}",
						i_HowManyToolsToConnectInARow,
						i_Rows,
						i_Columns));
			}

			r_HowManyToolsToConnectInARow = i_HowManyToolsToConnectInARow;
		}

		public override bool TryAddGameTool(int i_Column, T i_GameTool, out Index o_GameToolLocation)
		{
			o_GameToolLocation = new Index();
			bool isPlaceAvailable = !EqualityComparer<T>.Default.Equals(i_GameTool, default(T)) && IsCellHavingRoom(k_TopAvailabilityRow, i_Column);

			if (isPlaceAvailable)
			{
				const bool v_ValidateGameTool = false;
				o_GameToolLocation = addGameTool(i_Column, i_GameTool, v_ValidateGameTool);
			}

			return isPlaceAvailable;
		}

		public override Index AddGameTool(int i_Column, T i_GameTool)
		{
			const bool v_ValidateGameTool = true;
			return addGameTool(i_Column, i_GameTool, v_ValidateGameTool);
		}

		public override Index RemoveGameTool(int i_Column)
		{
			int topmostFilledRow = findNextAvailableRow(i_Column) + 1;
			this[topmostFilledRow, i_Column] = default(T);

			return new Index(topmostFilledRow, i_Column);
		}

		private Index addGameTool(int i_Column, T i_GameTool, bool i_ValidateGameTool)
		{
			if (i_ValidateGameTool)
			{
				if (EqualityComparer<T>.Default.Equals(i_GameTool, default(T)))
				{
					throw new IllegalPlayerMoveException(string.Format("Playing default game tool ({0}) is prohibited.", i_GameTool));
				}

				if (!IsCellHavingRoom(k_TopAvailabilityRow, i_Column))
				{
					throw new IllegalPlayerMoveException(string.Format("Unable to add game tool. Column {0} is full.", i_Column));
				}
			}

			int nextAvailableRow = findNextAvailableRow(i_Column);
			this[nextAvailableRow, i_Column] = i_GameTool;

			return new Index(nextAvailableRow, i_Column);
		}

		private int findNextAvailableRow(int i_Column)
		{
			int row = Rows - 1;
			bool isFound = false;

			while (!isFound && (row >= k_TopAvailabilityRow))
			{
				if (IsCellHavingRoom(row, i_Column))
				{
					isFound = true;
				}
				else
				{
					row--;
				}
			}

			return row;
		}

		public override bool OptionallyEvaluateWinner(Index i_SearchFrom, out ICollection<Index> o_GameToolsInARow)
		{
			bool hasWon = true;

			// Check for horizontal direction (-)
			o_GameToolsInARow = optionallyEvaluateWinnerInDirection(i_SearchFrom, Direction.Left, Direction.Right);
			if (o_GameToolsInARow.Count != r_HowManyToolsToConnectInARow)
			{
				// Check for vertical direction (|)
				o_GameToolsInARow = optionallyEvaluateWinnerInDirection(i_SearchFrom, Direction.Top, Direction.Bottom);
				if (o_GameToolsInARow.Count != r_HowManyToolsToConnectInARow)
				{
					// Check for positive slope direction (/)
					o_GameToolsInARow = optionallyEvaluateWinnerInDirection(i_SearchFrom, Direction.TopRight, Direction.BottomLeft);
					if (o_GameToolsInARow.Count != r_HowManyToolsToConnectInARow)
					{
						// Check for negative slope direction (\)
						o_GameToolsInARow = optionallyEvaluateWinnerInDirection(i_SearchFrom, Direction.TopLeft, Direction.BottomRight);
						hasWon = o_GameToolsInARow.Count == r_HowManyToolsToConnectInARow;
					}
				}
			}

			return hasWon;
		}

		private ICollection<Index> optionallyEvaluateWinnerInDirection(Index i_SearchFrom, params Direction[] i_Directions)
		{
			ICollection<Index> gameToolsInARow = new HashSet<Index>();

			foreach (Direction direction in i_Directions)
			{
				collectGameToolsInDirection(i_SearchFrom, gameToolsInARow, direction);
			}

			return gameToolsInARow;
		}

		private void collectGameToolsInDirection(Index i_SearchFrom, ICollection<Index> i_GameTools, Direction i_Direction)
		{
			T gameToolToLookFor = this[i_SearchFrom];
			int currentRow = i_SearchFrom.Row;
			int currentColumn = i_SearchFrom.Column;
			bool continueSearching = true;

			while (continueSearching && (i_GameTools.Count < r_HowManyToolsToConnectInARow) && HasValue(currentRow, currentColumn))
			{
				if (this[currentRow, currentColumn].Equals(gameToolToLookFor))
				{
					i_GameTools.Add(new Index(currentRow, currentColumn));
				}
				else
				{
					continueSearching = false;
				}

				currentRow += i_Direction.Row;
				currentColumn += i_Direction.Column;
			}
		}
	}
}