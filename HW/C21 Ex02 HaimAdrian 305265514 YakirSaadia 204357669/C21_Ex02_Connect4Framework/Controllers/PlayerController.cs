using C21_Ex02_Connect4Controller.Game.Player;
using C21_Ex02_Connect4Model.Game.Player;

namespace C21_Ex02_Connect4Framework.Controllers
{
	public sealed class PlayerController
	{
		private static readonly PlayerController sr_Instance = new PlayerController();

		private PlayerController()
		{
		}

		public static PlayerController Instance
		{
			get
			{
				return sr_Instance;
			}
		}

		public IPlayer<T> NewPlayer<T>(string i_PlayerId, string i_PlayerName)
		{
			return new Player<T>(i_PlayerId, i_PlayerName);
		}

		public IBot<T> NewBot<T>(eAiLevel i_AiLevel)
		{
			IBot<T> bot;

			// When the level is below rookie, use random algorithm.
			if (i_AiLevel < eAiLevel.Rookie)
			{
				bot = new BotRandom<T>();
			}
			else
			{
				bot = new BotAi<T>(i_AiLevel);
			}

			return bot;
		}
	}
}
