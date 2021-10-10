using Ex02.Connect4Engine.Api.Game.Engine;
using Ex02.Connect4Engine.Api.Game.Player;
using Ex02.Connect4Engine.Api.Matrix;

namespace Ex02.Connect4Engine.Core.Game.Engine
{
	/// <summary>
	/// Represents a board game engine internally to our library,
	/// so we will not expose player functionality.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	internal interface IInternalBoardGameEngine<T> : IBoardGameEngine<T>
	{
		new Index LastPlayerMove { get; set; }

		bool TryMakePlayerMove(IPlayer<T> i_Player, int i_Column, out Index o_Move);
	}
}
