using System.Collections.Generic;
using Ex02.Connect4Engine.Api.Matrix;
using Ex02.Connect4Engine.Api.System;

namespace Ex02.Connect4Engine.Api.Game.Board
{
	/// <summary>
	/// Represents board of a game
	/// </summary>
	/// <typeparam name="T">Type of game soldiers (game tool players play with)</typeparam>
	public interface IBoard<T>
	{
		T this[Index i_Index] { get; }

		T this[int i_Row, int i_Column] { get; }

		int Rows { get; }

		int Columns { get; }

		bool IsBoardFull { get; }

		void Clear();

		bool IsCellHavingRoom(int i_Row, int i_Column);

		bool TryAddGameTool(int i_Column, T i_GameTool, out Index o_GameToolLocation);

		Index AddGameTool(int i_Column, T i_GameTool);

		Index RemoveGameTool(int i_Column);

		bool OptionallyEvaluateWinner(Index i_SearchFrom, out ICollection<Index> o_GameToolsInARow);

		void AddBoardUpdatingListener(Action<IBoard<T>, Index, T> i_Listener);

		void AddBoardUpdatedListener(Action<IBoard<T>, ICollection<Index>> i_Listener);

		void SuspendUpdates();

		void ResumeUpdates();

		IBoard<T> Clone();

		string ToString(eBoardToStringOptions i_Options, ICollection<Index> i_IndicesToMark);

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
		string ToString(eBoardToStringOptions i_Options, char i_RowSeparator, char i_ColumnSeparator, ICollection<Index> i_IndicesToMark);
	}
}
