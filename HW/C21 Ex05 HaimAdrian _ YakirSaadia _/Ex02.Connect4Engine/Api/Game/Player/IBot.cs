using Ex02.Connect4Engine.Api.Game.Engine;
using Ex02.Connect4Engine.Api.Matrix;

namespace Ex02.Connect4Engine.Api.Game.Player
{
	public interface IBot<T> : IPlayer<T>
	{
		Index MakeMove(IBoardGameEngine<T> i_GameEngine);
	}
}