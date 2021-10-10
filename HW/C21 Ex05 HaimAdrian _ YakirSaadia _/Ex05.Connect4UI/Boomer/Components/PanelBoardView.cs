using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ex02.Connect4Engine.Api.Game.Board;
using Ex02.Connect4Engine.Api.Matrix;
using Ex05.Connect4UI.Normal.Components;

namespace Ex05.Connect4UI.Boomer.Components
{
	internal sealed class PanelBoardView : PanelDoubleBuffered
	{
		private const int k_ChipPadding = 10;

		private const int k_DoubleChipPadding = 2 * k_ChipPadding;

		private IBoard<eGameTool> m_Board;

		private ICollection<Index> m_WinningIndices;

		public PanelBoardView() : this(null)
		{
		}

		public PanelBoardView(IBoard<eGameTool> i_Board)
		{
			Board = i_Board;

			AutoSize = true;
			Reset();
			initButtons();
		}

		public static int ChipPadding
		{
			get
			{
				return k_ChipPadding;
			}
		}

		public IBoard<eGameTool> Board
		{
			get
			{
				return m_Board;
			}

			set
			{
				bool wasNull = m_Board == null;
				m_Board = value;

				if (wasNull && (value != null))
				{
					initButtons();
				}
			}
		}

		protected override void Dispose(bool i_Disposing)
		{
			Reset();

			base.Dispose(i_Disposing);
		}

		private void initButtons()
		{
			if (Board != null)
			{
				SuspendLayout();

				try
				{
					if (Controls.Count != 0)
					{
						removeButtons();
					}

					ButtonBoardCell button = null;
					for (int row = 0, yCoordinate = 0; row < Board.Rows; row++)
					{
						for (int column = 0, xCoordinate = k_DoubleChipPadding; column < Board.Columns; column++)
						{
							button = new ButtonBoardCell(row, column);
							button.Location = new Point(xCoordinate, yCoordinate);
							Controls.Add(button);
							xCoordinate += button.Width + k_DoubleChipPadding;
						}

						if (button != null)
						{
							button.Margin = new Padding(0, 0, k_DoubleChipPadding, 0);
							yCoordinate += button.Height + k_ChipPadding;
						}
					}
				}
				finally
				{
					ResumeLayout();
				}
			}
		}

		private void removeButtons()
		{
			SuspendLayout();

			try
			{
				foreach (object currentControl in Controls)
				{
					ButtonBoardCell button = currentControl as ButtonBoardCell;
					if (button != null)
					{
						button.Dispose();
					}
				}

				Controls.Clear();
			}
			finally
			{
				ResumeLayout();
			}
		}

		public void Refresh(ICollection<Index> i_WinIndices)
		{
			m_WinningIndices = i_WinIndices;
			Refresh();
		}

		public override void Refresh()
		{
			base.Refresh();

			if (Board != null)
			{
				foreach (object currentControl in Controls)
				{
					ButtonBoardCell currentButton = currentControl as ButtonBoardCell;
					if (currentButton != null)
					{
						currentButton.UpdateGameTool(Board[currentButton.Row, currentButton.Column]);

						if ((m_WinningIndices != null) && m_WinningIndices.Contains(new Index(currentButton.Row, currentButton.Column)))
						{
							currentButton.Font = new Font(currentButton.Font, FontStyle.Bold);
						}
						else if (currentButton.Font.Bold)
						{
							currentButton.Font = new Font(currentButton.Font, FontStyle.Regular);
						}
					}
				}
			}
		}

		public void Reset()
		{
			Board = null;
			m_WinningIndices = null;

			foreach (object currentControl in Controls)
			{
				ButtonBoardCell currentButton = currentControl as ButtonBoardCell;
				if (currentButton != null)
				{
					currentButton.UpdateGameTool(eGameTool.None);

					if (currentButton.Font.Bold)
					{
						currentButton.Font = new Font(currentButton.Font, FontStyle.Regular);
					}
				}
			}
		}
	}
}
