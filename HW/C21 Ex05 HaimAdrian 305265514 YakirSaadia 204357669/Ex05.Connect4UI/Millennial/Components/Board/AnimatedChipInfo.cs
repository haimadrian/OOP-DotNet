using System.Drawing;

namespace Ex05.Connect4UI.Millennial.Components.Board
{
	internal struct AnimatedChipInfo
	{
		private Point m_Location;

		private eGameTool m_GameTool;

		public AnimatedChipInfo(Point i_Location, eGameTool i_GameTool)
		{
			m_Location = i_Location;
			m_GameTool = i_GameTool;
		}

		public Point Location
		{
			get
			{
				return m_Location;
			}

			set
			{
				m_Location = value;
			}
		}

		public eGameTool GameTool
		{
			get
			{
				return m_GameTool;
			}

			set
			{
				m_GameTool = value;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return m_GameTool == eGameTool.None;
			}
		}

		public override string ToString()
		{
			return string.Format("{{ Location={0}, GameTool={1} }}", Location.ToString(), GameTool.ToString());
		}
	}
}