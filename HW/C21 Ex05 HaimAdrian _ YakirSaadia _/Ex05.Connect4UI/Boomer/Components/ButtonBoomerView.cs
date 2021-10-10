using System.Windows.Forms;

namespace Ex05.Connect4UI.Boomer.Components
{
	internal class ButtonBoomerView : Button
	{
		private const int k_ButtonWidth = 30;

		private const int k_ButtonHeight = 20;

		private readonly int r_ColumnIndex;

		public ButtonBoomerView(int i_ColumnIndex)
		{
			r_ColumnIndex = i_ColumnIndex;

			Width = k_ButtonWidth;
			Height = k_ButtonHeight;
		}

		public int Column
		{
			get
			{
				return r_ColumnIndex;
			}
		}
	}
}
