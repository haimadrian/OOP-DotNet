using System;
using System.Collections.Generic;
using Ex02.Connect4Engine.Api.Game.Action;
using Ex02.Connect4Engine.Api.Game.Board;
using Ex02.Connect4Engine.Api.Game.Player;
using Ex02.Connect4Engine.Api.Matrix;
using Ex02.Connect4Engine.Api.System;

namespace Ex02.Connect4Engine.Api.Game.Engine
{
	public interface IBoardGameEngine<T> : IActionKeeper
	{
		IBoard<T> Board { get; }

		List<IPlayer<T>> Players { get; }

		IPlayer<T> ActivePlayer { get; set; }

		IPlayer<T> LastActivePlayer { get; }

		Index LastPlayerMove { get; }

		bool IsGameOver { get; }

		bool AddPlayer(IPlayer<T> i_Player);

		void Start();

		void Restart();

		Index MakePlayerMove(IPlayer<T> i_Player, int i_Column);

		bool OptionallyPlayPcMove(out Index o_Move);

		void AddActivePlayerChangedListener(Action<IBoardGameEngine<T>, IPlayer<T>> i_Listener);

		void AddGameStartedListener(Action<IBoardGameEngine<T>> i_Listener);

		void AddGameOverListener(Action<IBoardGameEngine<T>, IPlayer<T>> i_Listener);

		void AddGameResumedListener(Action<IBoardGameEngine<T>> i_Listener);
	}
}