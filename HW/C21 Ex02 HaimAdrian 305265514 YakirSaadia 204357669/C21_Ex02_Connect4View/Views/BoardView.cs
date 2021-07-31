﻿using System;
using System.Collections.Generic;
using C21_Ex02_Connect4Controller.Game.Board;
using C21_Ex02_Connect4Controller.Matrix;

namespace C21_Ex02_Connect4View.Views
{
	internal class BoardView
	{
		private readonly IBoard<eGameTool> r_Board;

		public BoardView(IBoard<eGameTool> i_Board)
		{
			r_Board = i_Board;
		}

		private IBoard<eGameTool> Board
		{
			get
			{
				return r_Board;
			}
		}

		public void Refresh(ICollection<Index> i_WinIndices)
		{
			Console.WriteLine(Board.ToString(eBoardToStringOptions.DrawColumnNumbers | eBoardToStringOptions.DrawFrame, i_WinIndices));
		}
	}
}