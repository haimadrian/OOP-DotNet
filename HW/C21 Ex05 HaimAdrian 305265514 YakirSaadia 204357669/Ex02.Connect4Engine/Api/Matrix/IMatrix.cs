namespace Ex02.Connect4Engine.Api.Matrix
{
	public interface IMatrix<T>
	{
		T this[Index i_Index] { get; set; }

		T this[int i_Row, int i_Column] { get; set; }

		int Rows { get; }

		int Columns { get; }

		long Count { get; }

		void Clear();

		bool HasValue(Index i_Index);

		bool HasValue(int i_Row, int i_Column);
	}
}