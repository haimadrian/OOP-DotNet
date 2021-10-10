using System.Windows.Forms;

namespace Ex05.Connect4UI.Boomer.Components
{
	internal class ButtonBoardCell : ButtonBoomerView
	{
		private readonly int r_Row;

		public ButtonBoardCell(int i_Row, int i_Column) : base(i_Column)
		{
			r_Row = i_Row;
			Height = Width;

			TabStop = false;
			SetStyle(ControlStyles.Selectable, false);
		}

		public int Row
		{
			get
			{
				return r_Row;
			}
		}

		public void UpdateGameTool(eGameTool i_GameTool)
		{
			string text = string.Empty;
			if ((i_GameTool == eGameTool.O) || (i_GameTool == eGameTool.X))
			{
				text = i_GameTool.ToString();
			}

			Text = text;
		}
	}
}
