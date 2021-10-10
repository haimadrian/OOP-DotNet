using System.Drawing;
using System.Windows.Forms;

namespace Ex05.Connect4UI.Normal.Components
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
			private static readonly Color sr_MenuItemSelectedColor = Color.FromArgb(100, 100, 100);

			private static readonly Color sr_MenuItemBorderColor = Color.FromArgb(0, 30, 30, 30);

			private static readonly Color sr_MenuItemSelectedGradientBeginColor = Color.FromArgb(64, 64, 64);

			private static readonly Color sr_MenuItemSelectedGradientEndColor = Color.FromArgb(34, 34, 34);

			public override Color MenuItemSelected
			{
				get
				{
					return sr_MenuItemSelectedColor;
				}
			}

			public override Color MenuItemBorder
			{
				get
				{
					return sr_MenuItemBorderColor;
				}
			}

			public override Color MenuItemSelectedGradientBegin
			{
				get
				{
					return sr_MenuItemSelectedGradientBeginColor;
				}
			}

			public override Color MenuItemSelectedGradientEnd
			{
				get
				{
					return sr_MenuItemSelectedGradientEndColor;
				}
			}
		}
	}
}
