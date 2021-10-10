using System;
using System.Collections.Generic;
using System.Text;
using Ex02.Connect4Engine.Api.Matrix;

namespace Ex02.Connect4Engine.Core.Matrix
{
	internal class Matrix<T> : IMatrix<T>
	{
		private const int k_RowsDimension = 0;
		private const int k_ColumnsDimension = 1;
		private const int k_MinimumCharactersPerValueForToString = 3;
		private const char k_ArrayOpeningParentheses = '[';
		private const char k_ArrayClosingParentheses = ']';
		private const string k_ArraySeparator = ", ";

		private readonly T[,] r_Data;

		/// <summary>
		/// Count how many non-default values there are, to make it available in O(1) rather than
		/// a full search which takes O(n) where n=Rows*Cols
		/// </summary>
		private long m_Count;

		public Matrix(int i_Rows, int i_Columns)
		{
			r_Data = new T[i_Rows, i_Columns];
		}

		public Matrix(T[,] i_Data)
		{
			r_Data = new T[i_Data.GetLength(k_RowsDimension), i_Data.GetLength(k_ColumnsDimension)];

			for (int currentRowIndex = 0; currentRowIndex < Rows; currentRowIndex++)
			{
				for (int currentColumnIndex = 0; currentColumnIndex < Columns; currentColumnIndex++)
				{
					r_Data[currentRowIndex, currentColumnIndex] = i_Data[currentRowIndex, currentColumnIndex];

					if (HasValue(new Index(currentRowIndex, currentColumnIndex)))
					{
						Count++;
					}
				}
			}
		}

		public T this[Index i_Index]
		{
			get
			{
				return this[i_Index.Row, i_Index.Column];
			}

			set
			{
				this[i_Index.Row, i_Index.Column] = value;
			}
		}

		public T this[int i_Row, int i_Column]
		{
			get
			{
				if (isIndexValid(i_Row, i_Column))
				{
					return r_Data[i_Row, i_Column];
				}

				throw new IndexOutOfRangeException(getIndexOutOfRangeErrorMessage(i_Row, i_Column));
			}

			set
			{
				if (!isIndexValid(i_Row, i_Column))
				{
					throw new IndexOutOfRangeException(getIndexOutOfRangeErrorMessage(i_Row, i_Column));
				}

				bool wasValue = HasValue(i_Row, i_Column);

				r_Data[i_Row, i_Column] = value;

				bool hasValue = HasValue(i_Row, i_Column);
				if (wasValue && !hasValue)
				{
					Count--;
				}
				else if (!wasValue && hasValue)
				{
					Count++;
				}
			}
		}

		public int Rows
		{
			get
			{
				return r_Data.GetLength(k_RowsDimension);
			}
		}

		public int Columns
		{
			get
			{
				return r_Data.GetLength(k_ColumnsDimension);
			}
		}

		public long Count
		{
			get
			{
				return m_Count;
			}

			private set
			{
				m_Count = value;
			}
		}

		private string getIndexOutOfRangeErrorMessage(int i_Row, int i_Column)
		{
			return string.Format(
				"Specified index ({0}, {1}) is out of range. Row range is: [0, {2}]. Column range is: [0, {3}]",
				i_Row,
				i_Column,
				Rows - 1,
				Columns - 1);
		}

		public void Clear()
		{
			for (int currentRowIndex = 0; currentRowIndex < Rows; currentRowIndex++)
			{
				for (int currentColumnIndex = 0; currentColumnIndex < Columns; currentColumnIndex++)
				{
					this[currentRowIndex, currentColumnIndex] = default(T);
				}
			}
		}

		private bool isIndexValid(int i_Row, int i_Column)
		{
			return i_Row >= 0 && i_Row < Rows && i_Column >= 0 && i_Column < Columns;
		}

		public bool HasValue(Index i_Index)
		{
			return HasValue(i_Index.Row, i_Index.Column);
		}

		public bool HasValue(int i_Row, int i_Column)
		{
			bool hasValue = false;
			if (isIndexValid(i_Row, i_Column))
			{
				// When value differs from default value, it means there is value.
				hasValue = !EqualityComparer<T>.Default.Equals(this[i_Row, i_Column], default(T));
			}

			return hasValue;
		}

		public override string ToString()
		{
			StringBuilder matrixAsString = new StringBuilder(k_MinimumCharactersPerValueForToString * Rows * Columns);
			matrixAsString.Append(k_ArrayOpeningParentheses);

			for (int currentRow = 0; currentRow < Rows; currentRow++)
			{
				matrixAsString.Append(k_ArrayOpeningParentheses);
				for (int currentColumn = 0; currentColumn < Columns; currentColumn++)
				{
					string valueToAppend = this[currentRow, currentColumn].ToString();

					if (valueToAppend == string.Empty)
					{
						valueToAppend = " ";
					}

					matrixAsString.Append(valueToAppend).Append(k_ArraySeparator);
				}

				if (Columns > 0)
				{
					// Remove last ", "
					matrixAsString.Remove(matrixAsString.Length - k_ArraySeparator.Length, k_ArraySeparator.Length);
				}

				matrixAsString.Append(k_ArrayClosingParentheses).AppendLine();
			}

			if (Rows > 0)
			{
				// Remove last NewLine
				matrixAsString.Remove(matrixAsString.Length - Environment.NewLine.Length, Environment.NewLine.Length);
			}

			matrixAsString.Append(k_ArrayClosingParentheses);
			return matrixAsString.ToString();
		}
	}
}