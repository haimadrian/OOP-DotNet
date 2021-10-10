using Ex02.Connect4Engine.Api.Game.Player;
using Ex02.Connect4Engine.Core.Game.Engine;

namespace Ex02.Connect4Engine.Core.Game.Action
{
	internal class ActionContext<T>
	{
		private const int k_NoColumnPlayed = -1;

		private readonly ActionExecutor<T> r_ActionExecutor;
		private readonly IInternalBoardGameEngine<T> r_GameEngine;
		private readonly IPlayer<T> r_Player;
		private readonly int r_ColumnPlayed;

		public ActionContext(ActionExecutor<T> i_ActionExecutor, IInternalBoardGameEngine<T> i_GameEngine, IPlayer<T> i_Player, int? i_ColumnPlayed)
		{
			r_ActionExecutor = i_ActionExecutor;
			r_GameEngine = i_GameEngine;
			r_Player = i_Player;
			r_ColumnPlayed = i_ColumnPlayed ?? k_NoColumnPlayed;
		}

		public ActionExecutor<T> ActionExecutor
		{
			get
			{
				return r_ActionExecutor;
			}
		}

		public IInternalBoardGameEngine<T> GameEngine
		{
			get
			{
				return r_GameEngine;
			}
		}

		public IPlayer<T> Player
		{
			get
			{
				return r_Player;
			}
		}

		public int ColumnPlayed
		{
			get
			{
				return r_ColumnPlayed;
			}
		}
	}
}