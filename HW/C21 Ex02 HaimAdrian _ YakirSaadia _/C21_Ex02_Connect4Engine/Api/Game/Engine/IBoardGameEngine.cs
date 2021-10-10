using System.Collections.Generic;
using C21_Ex02_Connect4Engine.Api.Game.Action;
using C21_Ex02_Connect4Engine.Api.Game.Board;
using C21_Ex02_Connect4Engine.Api.Game.Player;
using C21_Ex02_Connect4Engine.Api.Matrix;

namespace C21_Ex02_Connect4Engine.Api.Game.Engine
{
	public interface IBoardGameEngine<T> : IActionKeeper
	{
		IBoard<T> Board { get; }

		List<IPlayer<T>> Players { get; }

		IPlayer<T> ActivePlayer { get; set; }

		IPlayer<T> LastActivePlayer { get; }

		Index LastPlayerMove { get; }

		bool AddPlayer(IPlayer<T> i_Player);

		void Start();

		void Restart();

		bool HasWinner(out ICollection<Index> o_GameToolsInARow);

		Index MakePlayerMove(IPlayer<T> i_Player, int i_Column);

		bool OptionallyPlayPcMove(out Index o_Move);
	}
}
