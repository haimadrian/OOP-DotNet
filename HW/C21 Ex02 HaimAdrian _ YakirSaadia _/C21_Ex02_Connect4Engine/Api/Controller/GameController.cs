using C21_Ex02_Connect4Engine.Api.Game.Engine;
using C21_Ex02_Connect4Engine.Core.Game.Engine;

namespace C21_Ex02_Connect4Engine.Api.Controller
{
	public sealed class GameController
	{
		private static readonly GameController sr_Instance = new GameController();

		private GameController()
		{
		}

		public static GameController Instance
		{
			get
			{
				return sr_Instance;
			}
		}

		public IBoardGameEngine<T> NewConnect4GameEngine<T>(int i_Rows, int i_Columns)
		{
			return new ConnectFourGameEngine<T>(i_Rows, i_Columns);
		}
	}
}