using System;
using System.Windows.Forms;

namespace Ex05.Connect4UI.Normal.Components
{
	/// <summary>
	/// This class supposed to be abstract class that implements the common stuff related to
	/// game settings frames, though the designer cannot create abstract classes and it fails.. So
	/// it is not abstract, and there is a default implementation for SelectedBoardSize.<br/>
	/// <br/>
	/// Author: Haim Adrian<br/>
	/// Since: 13-Aug-2021
	/// </summary>
	internal class FrameGameSettings : PanelDoubleBuffered
	{
		private const char k_BoardSizeSeparator = 'x';

		protected static void VerticalCenter(int i_ParentHeight, Control i_Control, int i_Relative)
		{
			i_Control.Top = Math.Max((i_ParentHeight / 2) - (i_Control.Size.Height / 2) - i_Relative, 0);
		}

		public int Rows
		{
			get
			{
				return int.Parse(SelectedBoardSize.Split(k_BoardSizeSeparator)[0]);
			}
		}

		public int Columns
		{
			get
			{
				return int.Parse(SelectedBoardSize.Split(k_BoardSizeSeparator)[1]);
			}
		}

		protected virtual string SelectedBoardSize
		{
			get
			{
				return "5x6";
			}
		}

		protected object[] GetBoardSizes()
		{
			const int k_MaximumSize = 10;
			const int k_MinimumSize = 4;

			object[] boardSizes = new object[(int)Math.Pow(k_MaximumSize - k_MinimumSize + 1, 2)];

			int i = 0;
			for (int rows = k_MinimumSize; rows <= k_MaximumSize; rows++)
			{
				for (int cols = k_MinimumSize; cols <= k_MaximumSize; cols++)
				{
					boardSizes[i++] = string.Format("{0}{1}{2}", rows, k_BoardSizeSeparator, cols);
				}
			}

			return boardSizes;
		}
	}
}
