using System;
using System.Windows.Forms;
using Ex02.Connect4Engine.Api.Controller;
using Ex02.Connect4Engine.Api.Game.Engine;
using Ex02.Connect4Engine.Api.Game.Player;
using Ex05.Connect4UI.Millennial.Forms;
using Ex05.Connect4UI.Properties;

namespace Ex05.Connect4UI.Boomer.Forms
{
	internal partial class FormGameSettings : Form
	{
		public FormGameSettings()
		{
			InitializeComponent();
		}

		private void checkBoxPlayer2_CheckedChanged(object i_Sender, EventArgs i_Args)
		{
			const string k_PcText = "[Computer]";

			m_TextBoxPlayer2.Enabled = m_CheckBoxPlayer2.Checked;
			if (!m_CheckBoxPlayer2.Checked)
			{
				m_TextBoxPlayer2.Text = k_PcText;
			}
			else if (m_TextBoxPlayer2.Text == k_PcText)
			{
				m_TextBoxPlayer2.Text = string.Empty;
			}
		}

		private void buttonSwitchToMillennial_Click(object i_Sender, EventArgs i_Args)
		{
			Hide();
			
			FormConnectFourApplication formConnectFourApplication = new FormConnectFourApplication();
			formConnectFourApplication.FormClosed += formConnectFourApplication_OnFormClosed;

			formConnectFourApplication.ShowDialog();
		}

		private void formConnectFourApplication_OnFormClosed(object i_Sender, FormClosedEventArgs i_Args)
		{
			Close();
		}

		private void buttonStart_Click(object i_Sender, EventArgs i_Args)
		{
			if ((m_TextBoxPlayer1.Text.Trim().Length > 0) && (m_TextBoxPlayer2.Text.Trim().Length > 0))
			{
				Hide();
				
				FormConnectFourMain formConnectFourMain = new FormConnectFourMain(initGameEngine());
				formConnectFourMain.FormClosed += formConnectFourApplication_OnFormClosed;

				formConnectFourMain.ShowDialog();
			}
			else
			{
				MessageBox.Show(Resources.TextNameIsMandatory, Resources.TextBoomerError, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private IBoardGameEngine<eGameTool> initGameEngine()
		{
			IBoardGameEngine<eGameTool> gameEngine =
				GameController.Instance.NewConnect4GameEngine<eGameTool>((int)m_NumericUpDownRows.Value, (int)m_NumericUpDownCols.Value);
			IPlayer<eGameTool> firstPlayer;
			IPlayer<eGameTool> secondPlayer;

			if (!m_CheckBoxPlayer2.Checked)
			{
				firstPlayer = PlayerController.Instance.NewPlayer<eGameTool>(m_TextBoxPlayer1.Text, m_TextBoxPlayer1.Text);
				secondPlayer = PlayerController.Instance.NewBot<eGameTool>(eAiLevel.Professional);
			}
			else
			{
				firstPlayer = PlayerController.Instance.NewPlayer<eGameTool>(m_TextBoxPlayer1.Text, m_TextBoxPlayer1.Text);
				secondPlayer = PlayerController.Instance.NewPlayer<eGameTool>(m_TextBoxPlayer2.Text, m_TextBoxPlayer2.Text);
			}

			firstPlayer.GameTool = eGameTool.O;
			secondPlayer.GameTool = eGameTool.X;

			gameEngine.AddPlayer(firstPlayer);
			gameEngine.AddPlayer(secondPlayer);
			gameEngine.ActivePlayer = firstPlayer;

			return gameEngine;
		}
	}
}