using System;

namespace Ex05.Connect4UI.Millennial.Components
{
	/// <summary>
	/// Game settings frame to configure a multi player match.<br/>
	/// <br/>
	/// Author: Haim Adrian<br/>
	/// Since: 13-Aug-2021
	/// </summary>
	internal sealed partial class FrameGameSettingsMultiPlayer : FrameGameSettings
	{
		public FrameGameSettingsMultiPlayer()
		{
			InitializeComponent();

			OnResize(null);

			fillInBoardSizes();

			m_TextBoxPlayer1.Focus();
		}

		public string Player1Name
		{
			get
			{
				return m_TextBoxPlayer1.Text;
			}
		}

		public string Player2Name
		{
			get
			{
				return m_TextBoxPlayer2.Text;
			}
		}

		protected override string SelectedBoardSize
		{
			get
			{
				return m_ComboBoxBoardSize.Text;
			}
		}

		protected override void OnResize(EventArgs i_Args)
		{
			// Vertically center the text boxes
			int[] rowHeights = m_TableLayoutPanel.GetRowHeights();
			if (rowHeights.Length > 0)
			{
				VerticalCenter(rowHeights[0], m_TextBoxPlayer1, 0);
				VerticalCenter(rowHeights[1], m_TextBoxPlayer2, 0);
				VerticalCenter(rowHeights[2], m_ComboBoxBoardSize, 0);
				VerticalCenter(rowHeights[2], m_LabelBoardSizeExplanation, m_ComboBoxBoardSize.Height);
			}

			base.OnResize(i_Args);
		}

		public void FocusPlayer1NameControl()
		{
			m_TextBoxPlayer1.Focus();
		}

		public void FocusPlayer2NameControl()
		{
			m_TextBoxPlayer2.Focus();
		}

		private void fillInBoardSizes()
		{
			m_ComboBoxBoardSize.Items.Clear();
			m_ComboBoxBoardSize.Items.AddRange(GetBoardSizes());

			// Select 5x6 by default
			m_ComboBoxBoardSize.Text = base.SelectedBoardSize;
		}
	}
}