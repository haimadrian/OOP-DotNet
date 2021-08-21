using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Ex02.Connect4Engine.Api.Game.Board;
using Ex02.Connect4Engine.Api.Matrix;
using Ex05.Connect4UI.Properties;

namespace Ex05.Connect4UI.Millennial.Components.Board
{
	/// <summary>
	/// This class responsible for painting a connect four board.<br/>
	/// We use the ChipRed and ChipYellow resources, in order to draw player tools. Red is O and yellow is X.<br/>
	/// As a result of supporting form resize in the application, we listen to the OnResize event and calculate the
	/// chip size and client area size, in order to reduce calculation steps during OnPaint.<br/>
	/// We expose a LocationToIndex method so FormConnectFourApplication can use, as it listens to mouse click on us.<br/>
	/// <br/>
	/// Author: Haim Adrian<br/>
	/// Since: 14-Aug-2021
	/// </summary>
	internal sealed class PanelBoardView : PanelDoubleBuffered
	{
		private readonly Brush r_BackgroundBrush;

		private IBoard<eGameTool> m_Board;

		private ICollection<Index> m_WinningIndices;

		private Rectangle m_BoardDrawingRectangle;

		private Region m_BoardDrawingRegion;

		private GameCellInfo m_GameCellInfo;

		private AnimatedChipInfo m_AnimatedChipInfo;

		public PanelBoardView()
		{
			r_BackgroundBrush = new SolidBrush(Color.FromArgb(34, 34, 34));

			Reset();
		}

		public IBoard<eGameTool> Board
		{
			get
			{
				return m_Board;
			}

			set
			{
				m_Board = value;
			}
		}

		public Bitmap RedChipImage
		{
			get
			{
				return m_GameCellInfo.RedChipImage;
			}
		}

		public Bitmap YellowChipImage
		{
			get
			{
				return m_GameCellInfo.YellowChipImage;
			}
		}

		protected override void Dispose(bool i_Disposing)
		{
			r_BackgroundBrush.Dispose();

			Reset();

			base.Dispose(i_Disposing);
		}

		public void Refresh(ICollection<Index> i_WinIndices)
		{
			m_WinningIndices = i_WinIndices;
			m_AnimatedChipInfo = new AnimatedChipInfo();
			Invalidate();
		}

		public void AnimateTo(Index i_Location, eGameTool i_GameTool)
		{
			Point location = IndexToLocation(i_Location);
			m_AnimatedChipInfo = new AnimatedChipInfo(location, i_GameTool);

			int step = Math.Max(location.Y / 100, 2);
			for (int yCoordinate = m_BoardDrawingRectangle.Y; yCoordinate < location.Y; yCoordinate += step)
			{
				// As we call DoEvents, we might get a Refresh during the loop, which stops the animation.
				// In this case, e.g. when user presses Ctrl+Y quickly, m_AnimatedChipInfo is set to null, so we'd like to stop the loop.
				if (m_AnimatedChipInfo.IsEmpty)
				{
					yCoordinate = location.Y;
				}
				else
				{
					m_AnimatedChipInfo.Location = new Point(location.X, yCoordinate);
					Invalidate();

					// Let the events run and don't block the main thread due to this loop
					// Otherwise we'll see no animation...
					Application.DoEvents();
				}
			}
		}

		public Index LocationToIndex(Point i_Location)
		{
			Index result = new Index(-1, -1);
			if (m_BoardDrawingRectangle.Contains(i_Location))
			{
				int row = Math.Max(i_Location.Y / m_GameCellInfo.Height, 0);
				int column = Math.Max(i_Location.X / m_GameCellInfo.Width, 0);

				if (Board != null)
				{
					row = Math.Min(row, Board.Rows - 1);
					column = Math.Min(column, Board.Columns - 1);
				}

				result = new Index(row, column);
			}

			return result;
		}

		public Point IndexToLocation(Index i_Index)
		{
			Point result = new Point(m_BoardDrawingRectangle.X, m_BoardDrawingRectangle.Y);
			if (i_Index.IsValid)
			{
				// DoubleChipPadding is the distance of the first chip from left side of board drawing rectangle, 
				// and another ChipPadding is the distance of a chip from left side of its column. Hence the shift.
				result = new Point(
					(i_Index.Column * m_GameCellInfo.Width) + m_GameCellInfo.DoubleChipPadding + m_GameCellInfo.ChipPadding,
					(i_Index.Row * m_GameCellInfo.Height) + m_GameCellInfo.DoubleChipPadding);
			}

			return result;
		}

		public void Reset()
		{
			Board = null;
			m_WinningIndices = null;

			if (m_GameCellInfo != null)
			{
				m_GameCellInfo.Dispose();
			}

			m_GameCellInfo = new GameCellInfo();
		}

		protected override void OnResize(EventArgs i_Args)
		{
			base.OnResize(i_Args);

			if (Board != null)
			{
				calculateSizeForDrawing();
				Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs i_Args)
		{
			base.OnPaint(i_Args);

			if (Board != null)
			{
				paintGameBoard(i_Args);
			}
		}

		private void paintGameBoard(PaintEventArgs i_Args)
		{
			if (m_GameCellInfo.ChipWidth == 0)
			{
				calculateSizeForDrawing();
			}

			Graphics graphics = i_Args.Graphics;

			// First, if there is an animated chip, paint it.
			if (!m_AnimatedChipInfo.IsEmpty)
			{
				graphics.DrawImage(m_GameCellInfo.GameToolToImage(m_AnimatedChipInfo.GameTool), m_AnimatedChipInfo.Location);
			}

			paintEmptyBoard(graphics);
			paintChips(graphics);
		}

		private void paintEmptyBoard(Graphics i_Graphics)
		{
			// Set our region as clip, so we will paint the board with holes
			// This way we can draw the board over the animated chip, and we still see it.
			i_Graphics.SetClip(m_BoardDrawingRegion, CombineMode.Replace);
			i_Graphics.SmoothingMode = SmoothingMode.HighQuality;
			i_Graphics.FillRectangle(Brushes.MediumBlue, m_BoardDrawingRectangle);
			i_Graphics.ResetClip();
		}

		private void paintChips(Graphics i_Graphics)
		{
			int xStart = m_BoardDrawingRectangle.X + m_GameCellInfo.ChipPadding;
			int yStart = m_BoardDrawingRectangle.Y + m_GameCellInfo.ChipPadding;

			for (int row = 0, yCoordinate = yStart; row < Board.Rows; yCoordinate += m_GameCellInfo.Height, row++)
			{
				for (int col = 0, xCoordinate = xStart; col < Board.Columns; xCoordinate += m_GameCellInfo.Width, col++)
				{
					Image image = m_GameCellInfo.GameToolToImage(Board[row, col]);
					if (image != null)
					{
						i_Graphics.DrawImage(image, new Point(xCoordinate, yCoordinate));
					}

					if (m_WinningIndices != null)
					{
						Index currentIndex = new Index(row, col);
						if (m_WinningIndices.Contains(currentIndex))
						{
							i_Graphics.DrawImage(
								m_GameCellInfo.ChipHighlightImage,
								new Point(xCoordinate - m_GameCellInfo.ChipPadding, yCoordinate - m_GameCellInfo.ChipPadding));
						}
					}
				}
			}
		}

		private void calculateSizeForDrawing()
		{
			m_BoardDrawingRectangle = new Rectangle(
				m_GameCellInfo.DoubleChipPadding,
				m_GameCellInfo.DoubleChipPadding,
				ClientRectangle.Width - (2 * m_GameCellInfo.DoubleChipPadding),
				ClientRectangle.Height - (2 * m_GameCellInfo.DoubleChipPadding));

			if (m_GameCellInfo != null)
			{
				m_GameCellInfo.Dispose();
			}

			m_GameCellInfo = new GameCellInfo();

			m_GameCellInfo.ChipWidth = Math.Max(
				(m_BoardDrawingRectangle.Width / Board.Columns) - m_GameCellInfo.DoubleChipPadding,
				m_GameCellInfo.DoubleChipPadding);
			m_GameCellInfo.ChipHeight = Math.Max(
				(m_BoardDrawingRectangle.Height / Board.Rows) - m_GameCellInfo.DoubleChipPadding,
				m_GameCellInfo.DoubleChipPadding);

			m_GameCellInfo.ChipHighlightImage = new Bitmap(Resources.ChipHighlight, m_GameCellInfo.Width, m_GameCellInfo.Height);
			m_GameCellInfo.RedChipImage = new Bitmap(Resources.ChipRed, m_GameCellInfo.ChipWidth, m_GameCellInfo.ChipHeight);
			m_GameCellInfo.YellowChipImage = new Bitmap(Resources.ChipYellow, m_GameCellInfo.ChipWidth, m_GameCellInfo.ChipHeight);

			prepareBoardPaintingRegionWithHoles();
		}

		private void prepareBoardPaintingRegionWithHoles()
		{
			m_BoardDrawingRegion = new Region(m_BoardDrawingRectangle);

			int xStart = m_BoardDrawingRectangle.X + m_GameCellInfo.ChipPadding;
			int yStart = m_BoardDrawingRectangle.Y + m_GameCellInfo.ChipPadding;

			for (int row = 0, yCoordinate = yStart; row < Board.Rows; yCoordinate += m_GameCellInfo.Height, row++)
			{
				for (int col = 0, xCoordinate = xStart; col < Board.Columns; xCoordinate += m_GameCellInfo.Width, col++)
				{
					Rectangle ellipseRect = new Rectangle(xCoordinate, yCoordinate, m_GameCellInfo.ChipWidth, m_GameCellInfo.ChipHeight);
					GraphicsPath path = new GraphicsPath();
					path.AddEllipse(ellipseRect);
					m_BoardDrawingRegion.Exclude(path);
				}
			}
		}
	}
}