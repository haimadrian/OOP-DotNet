using C21_Ex02_Connect4Engine.Api.Game.Engine;
using C21_Ex02_Connect4Engine.Api.Matrix;

namespace C21_Ex02_Connect4Engine.Api.Game.Player
{
	public interface IBot<T> : IPlayer<T>
	{
		Index MakeMove(IBoardGameEngine<T> i_GameEngine);
	}
}
