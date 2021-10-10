using System.Collections.Generic;
using Ex02.Connect4Engine.Api.Collections;
using Ex02.Connect4Engine.Api.Game.Board;
using Ex02.Connect4Engine.Api.Game.Exceptions;
using Ex02.Connect4Engine.Api.Matrix;
using Ex02.Connect4Engine.Api.System;

namespace Ex02.Connect4Engine.Core.Game.Board
{
	internal class ConnectBoard<T> : ABoard<T>
	{
		// A row we depend on to know if player can make a move in some column or not
		private const int k_TopAvailabilityRow = 0;

		private readonly int r_HowManyToolsToConnectInARow;

		private bool m_IsUpdating;

		public event Action<IBoard<T>, Index, T> BoardUpdating;

		public event Action<IBoard<T>, ICollection<Index>> BoardUpdated;

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
			m_IsUpdating = true;
		}

		public override bool TryAddGameTool(int i_Column, T i_GameTool, out Index o_GameToolLocation)
		{
			o_GameToolLocation = new Index();
			bool isPlaceAvailable = !EqualityComparer<T>.Default.Equals(i_GameTool, default(T)) && IsCellHavingRoom(k_TopAvailabilityRow, i_Column);

			if (isPlaceAvailable)
			{
				const bool v_ValidateGameTool = true;
				o_GameToolLocation = addGameTool(i_Column, i_GameTool, !v_ValidateGameTool);
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

			OnBoardUpdated(new HashSet<Index>());

			return new Index(topmostFilledRow, i_Column);
		}

		public override void Clear()
		{
			base.Clear();
			OnBoardUpdated(null);
		}

		public override void AddBoardUpdatingListener(Action<IBoard<T>, Index, T> i_Listener)
		{
			BoardUpdating += i_Listener;
		}

		public override void AddBoardUpdatedListener(Action<IBoard<T>, ICollection<Index>> i_Listener)
		{
			BoardUpdated += i_Listener;
		}

		public override void SuspendUpdates()
		{
			m_IsUpdating = false;
		}

		public override void ResumeUpdates()
		{
			m_IsUpdating = true;
		}

		public override IBoard<T> Clone()
		{
			// Don't use a shallow clone (MemberwiseClone) cause we need a new matrix.
			ConnectBoard<T> clone = new ConnectBoard<T>(Rows, Columns, r_HowManyToolsToConnectInARow);

			for (int row = 0; row < Rows; row++)
			{
				for (int column = 0; column < Columns; column++)
				{
					clone[row, column] = this[row, column];
				}
			}

			return clone;
		}

		protected virtual void OnBoardUpdating(Index i_Location, T i_GameTool)
		{
			if (m_IsUpdating && (BoardUpdating != null))
			{
				BoardUpdating.Invoke(this, i_Location, i_GameTool);
			}
		}

		protected virtual void OnBoardUpdated(ICollection<Index> i_LastIndices)
		{
			if (m_IsUpdating && (BoardUpdated != null))
			{
				BoardUpdated.Invoke(this, i_LastIndices);
			}
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
			Index selectedIndex = new Index(nextAvailableRow, i_Column);

			// Raise this event before setting the game tool to the matrix, so UI can draw animation.
			OnBoardUpdating(selectedIndex, i_GameTool);

			this[nextAvailableRow, i_Column] = i_GameTool;

			ICollection<Index> winningFour;
			if (!OptionallyEvaluateWinner(selectedIndex, out winningFour))
			{
				winningFour = new HashSet<Index>(1);
				winningFour.Add(selectedIndex);
			}

			OnBoardUpdated(winningFour);

			return selectedIndex;
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
