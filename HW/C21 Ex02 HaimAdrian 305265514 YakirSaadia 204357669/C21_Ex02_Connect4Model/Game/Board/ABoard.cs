using System;
using System.Collections.Generic;
using System.Text;
using C21_Ex02_Connect4Controller.Game.Board;
using C21_Ex02_Connect4Controller.Matrix;
using C21_Ex02_Connect4Model.Matrix;

namespace C21_Ex02_Connect4Model.Game.Board
{
	/// <summary>
	/// Represents board of a game
	/// </summary>
	/// <typeparam name="T">Type of game soldiers (game tool players play with)</typeparam>
	public abstract class ABoard<T> : IBoard<T>
	{
		private const int k_MinimumCharactersPerValueForToString = 4;
		private const char k_DefaultRowSeparatorChar = '=';
		private const char k_DefaultColumnSeparatorChar = '|';
		private const char k_PaddingChar = ' ';
		private const char k_MarkingChar = '*';

		private readonly IMatrix<T> r_BoardMatrix;

		protected ABoard(int i_Rows, int i_Columns)
		{
			r_BoardMatrix = new Matrix<T>(i_Rows, i_Columns);
		}

		private IMatrix<T> BoardMatrix
		{
			get
			{
				return r_BoardMatrix;
			}
		}

		public T this[Index i_Index]
		{
			get
			{
				return BoardMatrix[i_Index.Row, i_Index.Column];
			}

			protected set
			{
				BoardMatrix[i_Index.Row, i_Index.Column] = value;
			}
		}

		public T this[int i_Row, int i_Column]
		{
			get
			{
				return BoardMatrix[i_Row, i_Column];
			}

			protected set
			{
				BoardMatrix[i_Row, i_Column] = value;
			}
		}

		public int Rows
		{
			get
			{
				return BoardMatrix.Rows;
			}
		}

		public int Columns
		{
			get
			{
				return BoardMatrix.Columns;
			}
		}

		public bool IsBoardFull
		{
			get
			{
				return BoardMatrix.Count == (BoardMatrix.Rows * BoardMatrix.Columns);
			}
		}

		private static void appendSpacePrefixIfRowNumbersArePainted(StringBuilder i_StringBuilder, eBoardToStringOptions i_Options)
		{
			if ((i_Options & eBoardToStringOptions.DrawRowNumbers) != 0)
			{
				i_StringBuilder.Append(k_PaddingChar);
			}
		}

		public void Clear()
		{
			BoardMatrix.Clear();
		}

		public bool IsCellHavingRoom(int i_Row, int i_Column)
		{
			return !HasValue(i_Row, i_Column);
		}

		protected bool HasValue(int i_Row, int i_Column)
		{
			return BoardMatrix.HasValue(i_Row, i_Column);
		}

		public abstract bool TryAddGameTool(int i_Column, T i_GameTool, out Index o_GameToolLocation);

		public abstract Index AddGameTool(int i_Column, T i_GameTool);

		public abstract Index RemoveGameTool(int i_Column);

		public abstract bool OptionallyEvaluateWinner(Index i_SearchFrom, out ICollection<Index> o_GameToolsInARow);

		public override string ToString()
		{
			return ToString(eBoardToStringOptions.DrawColumnNumbers | eBoardToStringOptions.DrawFrame, null);
		}

		public string ToString(eBoardToStringOptions i_Options, ICollection<Index> i_IndicesToMark)
		{
			return ToString(i_Options, k_DefaultRowSeparatorChar, k_DefaultColumnSeparatorChar, i_IndicesToMark);
		}

		/// <summary>
		/// Use this method to get a formatted string representation of a matrix, using special options,
		/// column separator character (e.g. |) and row separator character (e.g. =)<br/>
		/// <example>For example: <code>matrix.ToString(eBoardToStringOptions.DrawColumnNumbers | eBoardToStringOptions.DrawFrame, '=', '|')</code><br/>
		/// Output:<code>
		/// ;1 2 3 4 5 6<br/>
		/// | | | | | | |<br/>
		/// =============<br/>
		/// | | | | | | |<br/>
		/// =============<br/>
		/// | | | | | | |<br/>
		/// =============<br/>
		/// | | | | | | |<br/>
		/// =============<br/>
		/// | | | | | | |<br/>
		/// =============
		/// </code>
		/// </example>
		/// </summary>
		/// <param name="i_Options">Options telling whether we need to draw headers (row number, column number) and frame</param>
		/// <param name="i_RowSeparator">A character to use as row separator. e.g. =</param>
		/// <param name="i_ColumnSeparator">A character to use as column separator. e.g. |</param>
		/// <param name="i_IndicesToMark">A collection (HashSet is preferred, though not mandatory) of indices to mark (for win)</param>
		/// <returns>String representation of this board, according to specified options</returns>
		public string ToString(eBoardToStringOptions i_Options, char i_RowSeparator, char i_ColumnSeparator, ICollection<Index> i_IndicesToMark)
		{
			// Default capacity of StringBuilder is 16. Hence we start with capacity of 4*sizeof(matrix) at least,
			// to avoid of many re-allocations during ToString construction.
			StringBuilder matrixAsString = new StringBuilder(k_MinimumCharactersPerValueForToString * BoardMatrix.Rows * BoardMatrix.Columns);

			// + 2 for space from left and right.
			int maximumValueWidth = findMaximumValueWidth() + 2;

			if ((i_IndicesToMark != null) && (i_IndicesToMark.Count > 0))
			{
				// Add 1 for the mark sign (k_MarkingChar)
				maximumValueWidth++;
			}

			optionallyDrawColumnNumbers(matrixAsString, i_Options, maximumValueWidth);
			drawDataAsTable(matrixAsString, i_Options, i_RowSeparator, i_ColumnSeparator, maximumValueWidth, i_IndicesToMark);

			return matrixAsString.ToString();
		}

		private int findMaximumValueWidth()
		{
			int maximumValueWidth = 1;

			for (int currentRowIndex = 0; currentRowIndex < BoardMatrix.Rows; currentRowIndex++)
			{
				for (int currentColumnIndex = 0; currentColumnIndex < BoardMatrix.Columns; currentColumnIndex++)
				{
					if (BoardMatrix.HasValue(currentRowIndex, currentColumnIndex))
					{
						maximumValueWidth = Math.Max(maximumValueWidth, BoardMatrix[currentRowIndex, currentColumnIndex].ToString().Length);
					}
				}
			}

			return maximumValueWidth;
		}

		private void optionallyDrawColumnNumbers(StringBuilder i_MatrixAsString, eBoardToStringOptions i_Options, int i_MaximumValueWidth)
		{
			if ((i_Options & eBoardToStringOptions.DrawColumnNumbers) != 0)
			{
				appendSpacePrefixIfRowNumbersArePainted(i_MatrixAsString, i_Options);

				for (int currentColNumber = 1; currentColNumber <= BoardMatrix.Columns; currentColNumber++)
				{
					i_MatrixAsString.Append(k_PaddingChar);
					appendStringCentered(i_MatrixAsString, currentColNumber.ToString(), i_MaximumValueWidth);
				}

				i_MatrixAsString.AppendLine();
			}
		}

		private void drawDataAsTable(
			StringBuilder i_MatrixAsString,
			eBoardToStringOptions i_Options,
			char i_RowSeparator,
			char i_ColumnSeparator,
			int i_MaximumValueWidth,
			ICollection<Index> i_IndicesToMark)
		{
			bool isDrawingRowNumbers = (i_Options & eBoardToStringOptions.DrawRowNumbers) != 0;
			bool isDrawingFrame = (i_Options & eBoardToStringOptions.DrawFrame) != 0;
			int lengthOfRowSeparator = (BoardMatrix.Columns * i_MaximumValueWidth) + (BoardMatrix.Columns + 1);

			for (int currentRowIndex = 0; currentRowIndex < BoardMatrix.Rows; currentRowIndex++)
			{
				if (isDrawingRowNumbers)
				{
					i_MatrixAsString.Append(currentRowIndex + 1);
				}

				if (isDrawingFrame)
				{
					i_MatrixAsString.Append(i_ColumnSeparator);
				}

				for (int currentColumnIndex = 0; currentColumnIndex < BoardMatrix.Columns; currentColumnIndex++)
				{
					string value = BoardMatrix.HasValue(currentRowIndex, currentColumnIndex) ? BoardMatrix[currentRowIndex, currentColumnIndex].ToString() : " ";

					// Append marking character, to mark indices based on user input
					// This helps us mark the winner
					if ((i_IndicesToMark != null) && i_IndicesToMark.Contains(new Index(currentRowIndex, currentColumnIndex)))
					{
						value += k_MarkingChar;
					}

					appendStringCentered(i_MatrixAsString, value, i_MaximumValueWidth);
					i_MatrixAsString.Append(i_ColumnSeparator);
				}

				if (!isDrawingFrame)
				{
					i_MatrixAsString.Remove(i_MatrixAsString.Length - 1, 1);
				}

				i_MatrixAsString.AppendLine();
				appendSpacePrefixIfRowNumbersArePainted(i_MatrixAsString, i_Options);
				i_MatrixAsString.Append(i_RowSeparator, lengthOfRowSeparator).AppendLine();
			}

			if (!isDrawingFrame)
			{
				int lastRowLength = lengthOfRowSeparator + Environment.NewLine.Length;
				i_MatrixAsString.Remove(i_MatrixAsString.Length - 1 - lastRowLength, lastRowLength);
			}
		}

		private void appendStringCentered(StringBuilder i_StringBuilder, string i_StringToAppend, int i_Width)
		{
			if (i_StringToAppend.Length >= i_Width)
			{
				i_StringBuilder.Append(i_StringToAppend);
			}
			else
			{
				int leftPadding = (i_Width - i_StringToAppend.Length) / 2;
				int rightPadding = i_Width - i_StringToAppend.Length - leftPadding;

				i_StringBuilder.Append(k_PaddingChar, leftPadding).Append(i_StringToAppend).Append(k_PaddingChar, rightPadding);
			}
		}

		protected struct Direction
		{
			private static readonly Direction sr_Left = new Direction(0, -1);
			private static readonly Direction sr_Right = new Direction(0, 1);
			private static readonly Direction sr_Top = new Direction(-1, 0);
			private static readonly Direction sr_Bottom = new Direction(1, 0);
			private static readonly Direction sr_TopLeft = new Direction(-1, -1);
			private static readonly Direction sr_TopRight = new Direction(-1, 1);
			private static readonly Direction sr_BottomLeft = new Direction(1, -1);
			private static readonly Direction sr_BottomRight = new Direction(1, 1);

			private readonly int r_Row;
			private readonly int r_Column;

			public Direction(int i_Row, int i_Column)
			{
				r_Row = i_Row;
				r_Column = i_Column;
			}

			public static Direction Left
			{
				get
				{
					return sr_Left;
				}
			}

			public static Direction Right
			{
				get
				{
					return sr_Right;
				}
			}

			public static Direction Top
			{
				get
				{
					return sr_Top;
				}
			}

			public static Direction Bottom
			{
				get
				{
					return sr_Bottom;
				}
			}

			public static Direction TopLeft
			{
				get
				{
					return sr_TopLeft;
				}
			}

			public static Direction TopRight
			{
				get
				{
					return sr_TopRight;
				}
			}

			public static Direction BottomLeft
			{
				get
				{
					return sr_BottomLeft;
				}
			}

			public static Direction BottomRight
			{
				get
				{
					return sr_BottomRight;
				}
			}

			public int Row
			{
				get
				{
					return r_Row;
				}
			}

			public int Column
			{
				get
				{
					return r_Column;
				}
			}
		}
	}
}