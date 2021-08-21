using System;
using Ex02.Connect4Engine.Api.Game.Player;

namespace Ex05.Connect4UI.Millennial.Components
{
	/// <summary>
	/// Game settings frame to configure a match against PC.<br/>
	/// <br/>
	/// Author: Haim Adrian<br/>
	/// Since: 13-Aug-2021
	/// </summary>
	internal partial class FrameGameSettingsPc : FrameGameSettings
	{
		public FrameGameSettingsPc()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs i_Args)
		{
			base.OnLoad(i_Args);

			OnResize(i_Args);

			fillInAiLevels();
			fillInBoardSizes();

			m_TextBoxPlayer.Focus();
		}

		protected override void OnResize(EventArgs i_Args)
		{
			// Vertically center the text boxes
			int[] rowHeights = m_TableLayoutPanel.GetRowHeights();
			if (rowHeights.Length > 0)
			{
				VerticalCenter(rowHeights[0], m_TextBoxPlayer, 0);
				VerticalCenter(rowHeights[1], m_ComboBoxDifficulty, 0);
				VerticalCenter(rowHeights[2], m_ComboBoxBoardSize, 0);
				VerticalCenter(rowHeights[2], m_LabelBoardSizeExplanation, m_ComboBoxBoardSize.Height);
			}

			base.OnResize(i_Args);
		}

		public string PlayerName
		{
			get
			{
				return m_TextBoxPlayer.Text;
			}
		}

		public eAiLevel Difficulty
		{
			get
			{
				return (eAiLevel)Enum.GetValues(typeof(eAiLevel)).GetValue(m_ComboBoxDifficulty.SelectedIndex + 1);
			}
		}

		protected override string SelectedBoardSize
		{
			get
			{
				return m_ComboBoxBoardSize.Text;
			}
		}

		public void FocusPlayerNameControl()
		{
			m_TextBoxPlayer.Focus();
		}

		private void fillInBoardSizes()
		{
			m_ComboBoxBoardSize.Items.Clear();
			m_ComboBoxBoardSize.Items.AddRange(GetBoardSizes());

			// Select 5x6 by default
			m_ComboBoxBoardSize.Text = base.SelectedBoardSize;
		}

		private void fillInAiLevels()
		{
			m_ComboBoxDifficulty.Items.Clear();
			foreach (eAiLevel currentAiLevel in Enum.GetValues(typeof(eAiLevel)))
			{
				if (currentAiLevel > eAiLevel.None)
				{
					m_ComboBoxDifficulty.Items.Add(currentAiLevel.ToString());
				}
			}

			// Select Professional by default
			m_ComboBoxDifficulty.Text = eAiLevel.Professional.ToString();
		}
	}
}