using System.Drawing;
using System.Windows.Forms;

namespace Ex05.Connect4UI.Millennial.Components
{
	/// <summary>
	/// This class created in order to highlight menu items when hovering over them,
	/// to override system color with custom gray color.<br/>
	/// <br/>
	/// Author: Haim Adrian<br/>
	/// Since: 13-Aug-2021
	/// </summary>
	public class MenuStripRenderer : ToolStripProfessionalRenderer
	{
		public MenuStripRenderer() : base(new BrowserColors())
		{
		}

		private class BrowserColors : ProfessionalColorTable
		{
			public override Color MenuItemSelected
			{
				get
				{
					return Color.FromArgb(100, 100, 100);
				}
			}

			public override Color MenuItemBorder
			{
				get
				{
					return Color.FromArgb(0, 30, 30, 30);
				}
			}

			public override Color MenuItemSelectedGradientBegin
			{
				get
				{
					return Color.FromArgb(64, 64, 64);
				}
			}

			public override Color MenuItemSelectedGradientEnd
			{
				get
				{
					return Color.FromArgb(34, 34, 34);
				}
			}
		}
	}
}