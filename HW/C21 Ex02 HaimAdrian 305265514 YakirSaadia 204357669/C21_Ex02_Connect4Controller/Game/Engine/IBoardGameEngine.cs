using System.Collections.Generic;
using C21_Ex02_Connect4Controller.Game.Board;
using C21_Ex02_Connect4Controller.Game.Player;
using C21_Ex02_Connect4Controller.Matrix;

namespace C21_Ex02_Connect4Controller.Game.Engine
{
	public interface IBoardGameEngine<T>
	{
		IBoard<T> Board { get; }

		List<IPlayer<T>> Players { get; }

		IPlayer<T> ActivePlayer { get; set; }

		IPlayer<T> LastActivePlayer { get; }

		bool AddPlayer(IPlayer<T> i_Player);

		void Start();

		void Restart();

		Index MakePlayerMove(IPlayer<T> i_Player, int i_Column, out ICollection<Index> o_GameToolsInARow);

		bool TryMakePlayerMove(IPlayer<T> i_Player, int i_Column, out ICollection<Index> o_GameToolsInARow, out Index o_Move);

		bool OptionallyPlayPcMove(out ICollection<Index> o_GameToolsInARow, out Index o_Move);
	}
}