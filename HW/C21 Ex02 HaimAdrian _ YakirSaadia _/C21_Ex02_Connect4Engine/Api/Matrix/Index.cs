namespace C21_Ex02_Connect4Engine.Api.Matrix
{
	public struct Index
	{
		private const int k_DefaultIndexValue = -1;

		private readonly int? r_Row;
		private readonly int? r_Column;

		public Index(int i_Row, int i_Column)
		{
			r_Row = i_Row;
			r_Column = i_Column;
		}

		public int Row
		{
			get
			{
				return r_Row ?? k_DefaultIndexValue;
			}
		}

		public int Column
		{
			get
			{
				return r_Column ?? k_DefaultIndexValue;
			}
		}

		public bool IsValid
		{
			get
			{
				return (Row >= 0) && (Column >= 0);
			}
		}

		public static bool operator ==(Index i_Index1, Index i_Index2)
		{
			return i_Index1.Equals(i_Index2);
		}

		public static bool operator !=(Index i_Player1, Index i_Player2)
		{
			return !(i_Player1 == i_Player2);
		}

		public override bool Equals(object i_Another)
		{
			return (i_Another != null) && (GetType() == i_Another.GetType()) && (Row == ((Index)i_Another).Row) && (Column == ((Index)i_Another).Column);
		}

		public override int GetHashCode()
		{
			// HashCode.Combine....
			int hash = 17;
			hash = (hash * 31) + Row.GetHashCode();
			hash = (hash * 31) + Column.GetHashCode();

			return hash;
		}
	}
}
