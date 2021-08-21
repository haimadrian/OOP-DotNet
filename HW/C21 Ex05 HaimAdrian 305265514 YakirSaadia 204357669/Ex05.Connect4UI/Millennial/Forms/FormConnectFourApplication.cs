using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Ex02.Connect4Engine.Api.Controller;
using Ex02.Connect4Engine.Api.Game.Board;
using Ex02.Connect4Engine.Api.Game.Engine;
using Ex02.Connect4Engine.Api.Game.Exceptions;
using Ex05.Connect4UI.Properties;
using Ex02.Connect4Engine.Api.Game.Player;
using Ex02.Connect4Engine.Api.Matrix;
using Ex02.Connect4Engine.Api.System;
using Ex05.Connect4UI.Boomer.Forms;
using Ex05.Connect4UI.Millennial.Components;

namespace Ex05.Connect4UI.Millennial.Forms
{
	/// <summary>
	/// Main window of our application.<br/>
	/// This window has a main menu with shortcuts, to let players see what actions they can make.<br/>
	/// In addition, there is a status bar at the bottom of the window, to show user current status of a game, and
	/// a progress bar when playing against AI and it takes time.<br/>
	/// This app uses custom dark style I've set using the designer and some code, like MenuStripRenderer.<br/>
	/// <br/>
	/// Author: Haim Adrian<br/>
	/// Since: 13-Aug-2021
	/// </summary>
	internal partial class FormConnectFourApplication : Form
	{
		private IBoardGameEngine<eGameTool> m_GameEngine;
		private FrameGameSettings m_FrameGameSettings;

		public FormConnectFourApplication()
		{
			InitializeComponent();
			m_MenuStripActions.Renderer = new MenuStripRenderer();
			m_PanelBoardView.MouseClick += panelBoardView_MouseClick;
			m_PanelBoardView.MouseMove += panelBoardView_MouseMove;
			m_PanelBoardView.MouseLeave += panelBoardView_MouseLeave;
		}

		private IBoardGameEngine<eGameTool> GameEngine
		{
			get
			{
				return m_GameEngine;
			}

			set
			{
				m_GameEngine = value;
			}
		}

		public void UpdateStatus(string i_Text)
		{
			UpdateStatus(i_Text, MessageBoxIcon.None);
		}

		public void UpdateStatus(string i_Text, MessageBoxIcon i_Icon)
		{
			// ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
			switch (i_Icon)
			{
				case MessageBoxIcon.Error:
					m_ToolStripStatusLabelGameStatus.Image = Resources.Error;
					break;
				case MessageBoxIcon.Warning:
					m_ToolStripStatusLabelGameStatus.Image = Resources.Warning;
					break;
				case MessageBoxIcon.Information:
					m_ToolStripStatusLabelGameStatus.Image = Resources.Info;
					break;
				default:
					m_ToolStripStatusLabelGameStatus.Image = null;
					break;
			}

			m_ToolStripStatusLabelGameStatus.Text = i_Text;
		}

		private void createAndStartNewGame()
		{
			GameEngine = GameController.Instance.NewConnect4GameEngine<eGameTool>(m_FrameGameSettings.Rows, m_FrameGameSettings.Columns);
			m_PanelBoardView.Board = GameEngine.Board;

			IPlayer<eGameTool> firstPlayer;
			IPlayer<eGameTool> secondPlayer;
			FrameGameSettingsPc settingsPc = m_FrameGameSettings as FrameGameSettingsPc;
			if (settingsPc != null)
			{
				firstPlayer = PlayerController.Instance.NewPlayer<eGameTool>(settingsPc.PlayerName, settingsPc.PlayerName);
				secondPlayer = PlayerController.Instance.NewBot<eGameTool>(settingsPc.Difficulty);
			}
			else
			{
				FrameGameSettingsMultiPlayer settingsMultiPlayer = m_FrameGameSettings as FrameGameSettingsMultiPlayer;

				// ReSharper disable once PossibleNullReferenceException
				firstPlayer = PlayerController.Instance.NewPlayer<eGameTool>(settingsMultiPlayer.Player1Name, settingsMultiPlayer.Player1Name);
				secondPlayer = PlayerController.Instance.NewPlayer<eGameTool>(settingsMultiPlayer.Player2Name, settingsMultiPlayer.Player2Name);
			}

			firstPlayer.GameTool = eGameTool.O;
			secondPlayer.GameTool = eGameTool.X;

			GameEngine.AddPlayer(firstPlayer);
			GameEngine.AddPlayer(secondPlayer);
			GameEngine.ActivePlayer = firstPlayer;

			UpdateStatus(Resources.TextReady);

			// Register event listeners
			GameEngine.AddActivePlayerChangedListener(gameEngine_ActivePlayerChanged);
			GameEngine.AddGameStartedListener(gameEngine_GameStarted);
			GameEngine.AddGameOverListener(gameEngine_GameOver);
			GameEngine.AddGameResumedListener(gameEngine_GameResumed);
			GameEngine.Board.AddBoardUpdatingListener(board_BoardUpdating);
			GameEngine.Board.AddBoardUpdatedListener(board_BoardUpdated);

			GameEngine.Start();
		}

		private void showGameSelectionButtons()
		{
			m_GameButtonPc.Visible = true;
			m_GameButtonMultiPlayer.Visible = true;
			m_PanelStartButtons.Visible = false;
			UpdateStatus(Resources.TextReady);
		}

		private void hideGameSelectionButtons()
		{
			m_GameButtonPc.Visible = false;
			m_GameButtonMultiPlayer.Visible = false;
			m_PanelStartButtons.Visible = true;
			UpdateStatus(Resources.TextConfiguring);
		}

		private void showSettingsPanel()
		{
			m_PanelGameSettings.Visible = true;
			m_PanelStartButtons.Visible = true;
		}

		private void hideSettingsPanel()
		{
			m_PanelGameSettings.Visible = false;
			m_PanelStartButtons.Visible = false;
		}

		private void updatePlayerScore(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			m_TableLayoutPanelScore.Visible = true;
			m_LabelPlayer1Score.Text = string.Format(Resources.TextPlayerScore, i_GameEngine.Players[0].Name, i_GameEngine.Players[0].Score);
			m_LabelPlayer2Score.Text = string.Format(Resources.TextPlayerScore, i_GameEngine.Players[1].Name, i_GameEngine.Players[1].Score);
		}

		private void hidePlayerScore()
		{
			m_TableLayoutPanelScore.Visible = false;
		}

		private void suspendUserInput()
		{
			m_PanelBoardView.MouseClick -= panelBoardView_MouseClick;
			m_ToolStripMenuItemUndo.Enabled = false;
			m_ToolStripMenuItemRedo.Enabled = false;
			m_ToolStripMenuItemRestart.Enabled = false;
		}

		private void resumeUserInput()
		{
			m_PanelBoardView.MouseClick += panelBoardView_MouseClick;
			m_ToolStripProgressBarPc.Visible = false;
			m_ToolStripMenuItemUndo.Enabled = true;
			m_ToolStripMenuItemRedo.Enabled = true;
			m_ToolStripMenuItemRestart.Enabled = true;
		}

		private void updateCursorBasedOnCurrentPlayer()
		{
			// Don't change cursor in case the mouse is outside board view area.
			if (m_PanelBoardView.Bounds.Contains(PointToClient(Cursor.Position)) && (GameEngine != null) && (GameEngine.ActivePlayer != null))
			{
				Bitmap bitmapToUse = GameEngine.ActivePlayer.GameTool == eGameTool.O ? m_PanelBoardView.RedChipImage : m_PanelBoardView.YellowChipImage;
				if (bitmapToUse != null)
				{
					Cursor = new Cursor(bitmapToUse.GetHicon());
				}
			}
		}

		/// <summary>
		/// This voodoo is here in order to make the setting controls repaint themselves 
		/// because there is something wrong with their location and a glitch while
		/// showing combo-box with selected item..
		/// </summary>
		private void doVoodooResize()
		{
			BeginInvoke(new Action(refreshGameSettings));
		}

		private void refreshGameSettings()
		{
			m_FrameGameSettings.Refresh();
		}

		private void gameEngine_ActivePlayerChanged(IBoardGameEngine<eGameTool> i_GameEngine, IPlayer<eGameTool> i_Player)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<IBoardGameEngine<eGameTool>, IPlayer<eGameTool>>(gameEngine_ActivePlayerChanged), i_GameEngine, i_Player);
			}
			else
			{
				// Might be null when player undo the first move
				if (i_Player != null)
				{
					UpdateStatus(string.Format(Resources.TextPlayerTurn, i_Player.Name));
					updateCursorBasedOnCurrentPlayer();
				}

				// Show progress bar during AI turn, and hide it during player's turn.
				m_ToolStripProgressBarPc.Visible = i_Player is IBot<eGameTool> && !i_GameEngine.IsGameOver;
			}
		}

		private void gameEngine_GameStarted(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action<IBoardGameEngine<eGameTool>>(gameEngine_GameStarted), i_GameEngine);
			}
			else
			{
				// Call the other event so we will update status bar
				gameEngine_ActivePlayerChanged(i_GameEngine, i_GameEngine.ActivePlayer);
				updatePlayerScore(i_GameEngine);
			}
		}

		private void gameEngine_GameOver(IBoardGameEngine<eGameTool> i_GameEngine, IPlayer<eGameTool> i_Winner)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action<IBoardGameEngine<eGameTool>, IPlayer<eGameTool>>(gameEngine_GameOver), i_GameEngine, i_Winner);
			}
			else
			{
				string text = i_Winner == null ? Resources.TextDraw : string.Format(Resources.TextWin, i_Winner.Name);
				UpdateStatus(text, MessageBoxIcon.Information);
				updatePlayerScore(i_GameEngine);
			}
		}

		private void gameEngine_GameResumed(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action<IBoardGameEngine<eGameTool>>(gameEngine_GameResumed), i_GameEngine);
			}
			else
			{
				updatePlayerScore(i_GameEngine);
			}
		}

		private void board_BoardUpdating(IBoard<eGameTool> i_Board, Index i_Location, eGameTool i_GameTool)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<IBoard<eGameTool>, Index, eGameTool>(board_BoardUpdating), i_Board, i_Location, i_GameTool);
			}
			else
			{
				m_PanelBoardView.Board = i_Board;
				m_PanelBoardView.AnimateTo(i_Location, i_GameTool);
			}
		}

		private void board_BoardUpdated(IBoard<eGameTool> i_Board, ICollection<Index> i_WinningFour)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action<IBoard<eGameTool>, ICollection<Index>>(board_BoardUpdated), i_Board, i_WinningFour);
			}
			else
			{
				m_PanelBoardView.Board = i_Board;
				m_PanelBoardView.Refresh(i_WinningFour);
			}
		}

		private void panelBoardView_MouseClick(object i_Sender, MouseEventArgs i_Args)
		{
			bool isPlaying = false;

			// Don't let user to play too fast and steal moves
			suspendUserInput();

			if (GameEngine.IsGameOver)
			{
				UpdateStatus(Resources.TextGameOverRestart, MessageBoxIcon.Error);
			}
			else if (GameEngine.ActivePlayer is IBot<eGameTool>)
			{
				UpdateStatus(string.Format(Resources.TextNotYourTurn, GameEngine.ActivePlayer.Name), MessageBoxIcon.Error);
			}
			else
			{
				Index selectedIndex = m_PanelBoardView.LocationToIndex(i_Args.Location);

				if (selectedIndex.IsValid)
				{
					try
					{
						GameEngine.MakePlayerMove(GameEngine.ActivePlayer, selectedIndex.Column);

						if (!GameEngine.IsGameOver)
						{
							isPlaying = true;

							// Run it using another thread so we will be able to see progress bar animation
							m_ToolStripProgressBarPc.Visible = true;
							ThreadPool.QueueUserWorkItem(pcTurnThreadProc);
						}
					}
					catch (IllegalPlayerMoveException e)
					{
						UpdateStatus(e.Message, MessageBoxIcon.Error);
					}
				}
			}

			if (!isPlaying)
			{
				resumeUserInput();
			}
		}

		private void pcTurnThreadProc(object i_StateInfo)
		{
			try
			{
				Index ignore;
				GameEngine.OptionallyPlayPcMove(out ignore);
			}
			finally
			{
				if (InvokeRequired)
				{
					Invoke(new Action(resumeUserInput));
				}
				else
				{
					resumeUserInput();
				}
			}
		}

		private void panelBoardView_MouseMove(object i_Sender, MouseEventArgs i_Args)
		{
			// Set the cursor only when it is set to default, and use a new reference because the 
			// image might be resized, depends on board sizing calculation.
			if (Cursor == Cursors.Default)
			{
				updateCursorBasedOnCurrentPlayer();
			}
		}

		private void panelBoardView_MouseLeave(object i_Sender, EventArgs i_Args)
		{
			Cursor = Cursors.Default;
		}

		private void gameButtonPc_Click(object i_Sender, EventArgs i_Args)
		{
			if (m_FrameGameSettings == null)
			{
				hideGameSelectionButtons();
				m_FrameGameSettings = new FrameGameSettingsPc();
				m_FrameGameSettings.Dock = DockStyle.Fill;
				m_PanelGameSettings.Controls.Add(m_FrameGameSettings);

				doVoodooResize();
			}
		}

		private void gameButtonMultiPlayer_Click(object i_Sender, EventArgs i_Args)
		{
			if (m_FrameGameSettings == null)
			{
				hideGameSelectionButtons();
				m_FrameGameSettings = new FrameGameSettingsMultiPlayer();
				m_FrameGameSettings.Dock = DockStyle.Fill;
				m_PanelGameSettings.Controls.Add(m_FrameGameSettings);

				doVoodooResize();
			}
		}

		private void formConnectFourApplication_FormClosing(object i_Sender, FormClosingEventArgs i_Args)
		{
			if (Visible &&
				(GameEngine != null) &&
				(FormMessageBox.Show(this, Resources.TextExitConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes))
			{
				// Cancel the Closing event from closing the form.
				i_Args.Cancel = true;
			}
		}

		private void toolStripMenuItem_DropDownToggle(object i_Sender, EventArgs i_Args)
		{
			// I've implemented this event because a group menu item changes its background color
			// to white when it is opened, and I cannot override this behavior... So I modify
			// the fore color (text) to black and white, based on tool strip drop down open/close events.
			ToolStripMenuItem toolStripMenuItem = i_Sender as ToolStripMenuItem;

			// ReSharper disable once PossibleNullReferenceException
			toolStripMenuItem.ForeColor = (toolStripMenuItem.ForeColor == Color.White) ? Color.Black : Color.White;
		}

		private void exitToolStripMenuItem_Click(object i_Sender, EventArgs i_Args)
		{
			// This will trigger the FormClosing event
			Close();
		}

		private void undoToolStripMenuItem_Click(object i_Sender, EventArgs i_Args)
		{
			if ((GameEngine != null) && (!GameEngine.UndoLastMove()))
			{
				UpdateStatus(Resources.TextNothingToUndo, MessageBoxIcon.Information);
			}

			// PC progress bar should be hidden during undo/redo, since undo move is under player control.
			m_ToolStripProgressBarPc.Visible = false;
		}

		private void redoToolStripMenuItem_Click(object i_Sender, EventArgs i_Args)
		{
			suspendUserInput();

			try
			{
				if ((GameEngine != null) && (!GameEngine.RedoLastMove()))
				{
					UpdateStatus(Resources.TextNothingToRedo, MessageBoxIcon.Information);
				}

				// PC progress bar should be hidden during undo/redo, since undo move is under player control.
				m_ToolStripProgressBarPc.Visible = false;
			}
			finally
			{
				resumeUserInput();
			}
		}

		private void restartToolStripMenuItem_Click(object i_Sender, EventArgs i_Args)
		{
			if (GameEngine != null)
			{
				GameEngine.Restart();
			}
		}

		private void homeToolStripMenuItem_Click(object i_Sender, EventArgs i_Args)
		{
			if (GameEngine != null)
			{
				GameEngine.Restart();
				GameEngine = null;
				m_PanelBoardView.Reset();
			}

			disposeFrameGameSettings();

			hidePlayerScore();
			showSettingsPanel();
			showGameSelectionButtons();
			Cursor = Cursors.Default;
		}

		private void boomerViewToolStripMenuItem_Click(object i_Sender, EventArgs i_Args)
		{
			Hide();

			FormGameSettings formGameSettings = new FormGameSettings();
			formGameSettings.FormClosed += formGameSettings_OnFormClosed;

			formGameSettings.ShowDialog();
		}

		private void formGameSettings_OnFormClosed(object i_Sender, FormClosedEventArgs i_Args)
		{
			Close();
		}

		private void buttonBack_Click(object i_Sender, EventArgs i_Args)
		{
			disposeFrameGameSettings();
			showGameSelectionButtons();
		}

		private void buttonStart_Click(object i_Sender, EventArgs i_Args)
		{
			UpdateStatus(Resources.TextValidatingSettings);

			if (validateUserSettings())
			{
				createAndStartNewGame();
				disposeFrameGameSettings();
				hideSettingsPanel();
			}
		}

		private void disposeFrameGameSettings()
		{
			if (m_FrameGameSettings != null)
			{
				m_PanelGameSettings.Controls.Remove(m_FrameGameSettings);
				m_FrameGameSettings.Dispose();
				m_FrameGameSettings = null;
			}
		}

		private bool validateUserSettings()
		{
			bool isValid = true;
			FrameGameSettingsPc settingsPc = m_FrameGameSettings as FrameGameSettingsPc;
			if (settingsPc != null)
			{
				if (string.IsNullOrEmpty(settingsPc.PlayerName))
				{
					isValid = false;
					UpdateStatus(Resources.TextNameIsMandatory, MessageBoxIcon.Error);
					settingsPc.FocusPlayerNameControl();
				}
			}
			else
			{
				FrameGameSettingsMultiPlayer settingsMultiPlayer = m_FrameGameSettings as FrameGameSettingsMultiPlayer;

				// ReSharper disable once PossibleNullReferenceException
				if (string.IsNullOrEmpty(settingsMultiPlayer.Player1Name))
				{
					isValid = false;
					UpdateStatus(Resources.TextNameIsMandatory, MessageBoxIcon.Error);
					settingsMultiPlayer.FocusPlayer1NameControl();
				}
				else if (string.IsNullOrEmpty(settingsMultiPlayer.Player2Name))
				{
					isValid = false;
					UpdateStatus(Resources.TextNameIsMandatory, MessageBoxIcon.Error);
					settingsMultiPlayer.FocusPlayer2NameControl();
				}
			}

			return isValid;
		}
	}
}