using System;

namespace Ex02.Connect4Engine.Api.Game.Board
{
	[Flags]
	public enum eBoardToStringOptions
	{
		NoHeaders = 0,
		DrawColumnNumbers = 1,
		DrawRowNumbers = 2,
		DrawFrame = 4
	}
}