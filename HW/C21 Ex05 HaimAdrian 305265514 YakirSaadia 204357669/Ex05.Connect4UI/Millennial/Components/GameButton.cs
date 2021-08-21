using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.Connect4UI.Millennial.Components
{
	/// <summary>
	/// A custom game button to use images for having better style for buttons.<br/>
	/// Here we override mouse events to make highlight and click effects.<br/>
	/// <br/>
	/// Author: Haim Adrian<br/>
	/// Since: 13-Aug-2021
	/// </summary>
	internal class GameButton : Button
	{
		private bool m_IsMouseDown;

		public GameButton()
		{
			m_IsMouseDown = false;
			initializeComponent();
		}

		private void initializeComponent()
		{
			BackColor = Color.Transparent;
			BackgroundImage = Properties.Resources.Button;
			BackgroundImageLayout = ImageLayout.Stretch;
			FlatStyle = FlatStyle.Flat;
			Font = new Font("Lucida Calligraphy", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ForeColor = Color.White;
			UseVisualStyleBackColor = false;
			FlatAppearance.MouseDownBackColor = Color.Transparent;
			FlatAppearance.MouseOverBackColor = Color.Transparent;
			FlatAppearance.BorderSize = 0;
			FlatAppearance.BorderColor = Color.FromArgb(34, 34, 34);
			TabStop = false;
		}

		// MouseHover has a delay, and it is not responsive.. Use MouseMove instead
		protected override void OnMouseMove(MouseEventArgs i_Args)
		{
			if (!m_IsMouseDown)
			{
				BackgroundImage = Properties.Resources.ButtonHover;
			}

			base.OnMouseMove(i_Args);
		}

		protected override void OnMouseDown(MouseEventArgs i_Args)
		{
			m_IsMouseDown = true;
			BackgroundImage = Properties.Resources.ButtonDown;
			base.OnMouseDown(i_Args);
		}

		protected override void OnMouseUp(MouseEventArgs i_Args)
		{
			doMouseLeaveOrUp();
			base.OnMouseUp(i_Args);
		}

		protected override void OnMouseLeave(EventArgs i_Args)
		{
			doMouseLeaveOrUp();
			base.OnMouseLeave(i_Args);
		}

		private void doMouseLeaveOrUp()
		{
			m_IsMouseDown = false;
			BackgroundImage = Properties.Resources.Button;
		}
	}
}