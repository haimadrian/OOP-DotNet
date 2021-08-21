using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.Connect4UI.Boomer.Components
{
	internal sealed class PanelBoardActionsView : Panel
	{
		private const int k_DefaultColumns = 6;

		private readonly int r_DoubleChipPadding;

		private int m_Count;

		// Support listening to all buttons at once.
		public event EventHandler<EventArgs> ActionButtonClick;

		public PanelBoardActionsView() : this(k_DefaultColumns)
		{
		}

		public PanelBoardActionsView(int i_Count)
		{
			r_DoubleChipPadding = 2 * PanelBoardView.ChipPadding;
			AutoSize = true;
			DoubleBuffered = true;
			Count = i_Count;
		}

		public int Count
		{
			get
			{
				return m_Count;
			}

			set
			{
				m_Count = value;
				initButtons();
			}
		}

		public void Reset()
		{
			foreach (object currentControl in Controls)
			{
				ButtonBoomerView button = currentControl as ButtonBoomerView;
				if (button != null)
				{
					button.Enabled = true;
				}
			}
		}

		// Class is sealed, hence this method is private and not protected virtual (!!!)
		private void onActionButtonClick(object i_Sender, EventArgs i_Args)
		{
			if (ActionButtonClick != null)
			{
				ActionButtonClick.Invoke(i_Sender, i_Args);
			}
		}

		private void button_Click(object i_Sender, EventArgs i_Args)
		{
			onActionButtonClick(i_Sender, i_Args);
		}

		private void initButtons()
		{
			SuspendLayout();

			try
			{
				if (Controls.Count != 0)
				{
					removeButtons();
				}

				ButtonBoomerView button = null;
				for (int column = 0, xCoordinate = r_DoubleChipPadding; column < Count; column++)
				{
					button = new ButtonBoomerView(column);
					button.Text = (column + 1).ToString();
					button.Location = new Point(xCoordinate, r_DoubleChipPadding);
					button.Margin = new Padding(0, 0, 0, r_DoubleChipPadding);
					button.TextAlign = ContentAlignment.MiddleCenter;
					button.Click += button_Click;
					Controls.Add(button);
					xCoordinate += button.Width + r_DoubleChipPadding;
				}

				if (button != null)
				{
					button.Margin = new Padding(0, 0, r_DoubleChipPadding, r_DoubleChipPadding);
				}
			}
			finally
			{
				ResumeLayout();
			}
		}

		private void removeButtons()
		{
			SuspendLayout();

			try
			{
				foreach (object currentControl in Controls)
				{
					ButtonBoomerView button = currentControl as ButtonBoomerView;
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
	}
}