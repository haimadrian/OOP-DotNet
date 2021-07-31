using System.Collections.Generic;
using C21_Ex02_Connect4Controller.Game.Engine;
using C21_Ex02_Connect4Controller.Matrix;

namespace C21_Ex02_Connect4Controller.Game.Player
{
	public interface IBot<T> : IPlayer<T>
	{
		Index MakeMove(IBoardGameEngine<T> i_GameEngine, out ICollection<Index> o_GameToolsInARow);
	}
}