using Ex02.Connect4Engine.Api.Game.Player;

namespace Ex02.Connect4Engine.Core.Game.Player
{
	internal class Player<T> : IPlayer<T>
	{
		private readonly string r_Id;
		private string m_Name;
		private T m_GameTool;
		private int m_Score;

		public Player(string i_Id, string i_Name)
		{
			r_Id = i_Id;
			m_Name = i_Name;
		}

		public string Id
		{
			get
			{
				return r_Id;
			}
		}

		public string Name
		{
			get
			{
				return m_Name;
			}

			set
			{
				m_Name = value;
			}
		}

		public T GameTool
		{
			get
			{
				return m_GameTool;
			}

			set
			{
				m_GameTool = value;
			}
		}

		public int Score
		{
			get
			{
				return m_Score;
			}

			set
			{
				m_Score = value;
			}
		}

		public static bool operator ==(Player<T> i_Player1, IPlayer<T> i_Player2)
		{
			return (ReferenceEquals(i_Player1, null) && ReferenceEquals(i_Player2, null)) || (!ReferenceEquals(i_Player1, null) && i_Player1.Equals(i_Player2));
		}

		public static bool operator !=(Player<T> i_Player1, IPlayer<T> i_Player2)
		{
			return !(i_Player1 == i_Player2);
		}

		public override string ToString()
		{
			return string.Format("Id: {0}, Name: {1}, GameTool: {2}", Id, Name, GameTool);
		}

		public override bool Equals(object i_Another)
		{
			bool equals = false;

			if ((i_Another != null) && (i_Another.GetType() == GetType()))
			{
				equals = string.Equals(Id, ((Player<T>)i_Another).Id);
			}

			return equals;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
