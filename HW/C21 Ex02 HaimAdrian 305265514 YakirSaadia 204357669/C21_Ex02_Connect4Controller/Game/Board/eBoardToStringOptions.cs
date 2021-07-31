using System;

namespace C21_Ex02_Connect4Controller.Game.Board
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