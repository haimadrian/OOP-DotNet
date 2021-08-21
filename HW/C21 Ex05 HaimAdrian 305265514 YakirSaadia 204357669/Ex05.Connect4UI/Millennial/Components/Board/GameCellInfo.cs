using System;
using System.Drawing;

namespace Ex05.Connect4UI.Millennial.Components.Board
{
	internal class GameCellInfo : IDisposable
	{
		private const int k_ChipPadding = 5;

		private const int k_DoubleChipPadding = 2 * k_ChipPadding;

		private int m_ChipWidth;

		private int m_ChipHeight;

		private Bitmap m_ChipHighlightImage;

		private Bitmap m_RedChipImage;

		private Bitmap m_YellowChipImage;

		public int ChipPadding
		{
			get
			{
				return k_ChipPadding;
			}
		}

		public int DoubleChipPadding
		{
			get
			{
				return k_DoubleChipPadding;
			}
		}

		public int ChipWidth
		{
			get
			{
				return m_ChipWidth;
			}

			set
			{
				m_ChipWidth = value;
			}
		}

		public int ChipHeight
		{
			get
			{
				return m_ChipHeight;
			}

			set
			{
				m_ChipHeight = value;
			}
		}

		public int Width
		{
			get
			{
				return k_DoubleChipPadding + ChipWidth;
			}
		}

		public int Height
		{
			get
			{
				return k_DoubleChipPadding + ChipHeight;
			}
		}

		public Bitmap ChipHighlightImage
		{
			get
			{
				return m_ChipHighlightImage;
			}

			set
			{
				m_ChipHighlightImage = value;
			}
		}

		public Bitmap RedChipImage
		{
			get
			{
				return m_RedChipImage;
			}

			set
			{
				m_RedChipImage = value;
			}
		}

		public Bitmap YellowChipImage
		{
			get
			{
				return m_YellowChipImage;
			}

			set
			{
				m_YellowChipImage = value;
			}
		}

		public void Dispose()
		{
			ChipWidth = 0;
			ChipHeight = 0;

			if (ChipHighlightImage != null)
			{
				ChipHighlightImage.Dispose();
				ChipHighlightImage = null;
			}

			if (RedChipImage != null)
			{
				RedChipImage.Dispose();
				RedChipImage = null;
			}

			if (YellowChipImage != null)
			{
				YellowChipImage.Dispose();
				YellowChipImage = null;
			}
		}

		public Image GameToolToImage(eGameTool i_GameTool)
		{
			Image result;

			// ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
			switch (i_GameTool)
			{
				case eGameTool.O:
					result = m_RedChipImage;
					break;
				case eGameTool.X:
					result = m_YellowChipImage;
					break;
				default:
					result = null;
					break;
			}

			return result;
		}

		public override string ToString()
		{
			return string.Format("{{ ChipWidth={0}, ChipHeight={1}, Width={2}, Height={3} }}", ChipWidth, ChipHeight, Width, Height);
		}
	}
}