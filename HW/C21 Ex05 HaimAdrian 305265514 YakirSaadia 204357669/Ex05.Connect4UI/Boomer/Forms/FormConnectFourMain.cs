using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ex02.Connect4Engine.Api.Controller;
using Ex02.Connect4Engine.Api.Game.Board;
using Ex02.Connect4Engine.Api.Game.Engine;
using Ex02.Connect4Engine.Api.Game.Exceptions;
using Ex02.Connect4Engine.Api.Game.Player;
using Ex02.Connect4Engine.Api.Matrix;
using Ex02.Connect4Engine.Api.System;
using Ex05.Connect4UI.Millennial.Forms;
using Ex05.Connect4UI.Properties;

namespace Ex05.Connect4UI.Boomer.Forms
{
	internal partial class FormConnectFourMain : Form
	{
		private const int k_DefaultRows = 5;

		private const int k_DefaultColumns = 6;

		private IBoardGameEngine<eGameTool> m_GameEngine;

		public FormConnectFourMain() : this(GameController.Instance.NewConnect4GameEngine<eGameTool>(k_DefaultRows, k_DefaultColumns))
		{
		}

		public FormConnectFourMain(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			GameEngine = i_GameEngine;
			InitializeComponent();
			m_PanelBoardActionsView.Count = GameEngine.Board.Columns;
			m_PanelBoardView.Board = GameEngine.Board;
			startGame();
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

		private void startGame()
		{
			// Register event listeners
			GameEngine.AddActivePlayerChangedListener(gameEngine_ActivePlayerChanged);
			GameEngine.AddGameStartedListener(gameEngine_GameStarted);
			GameEngine.AddGameOverListener(gameEngine_GameOver);
			GameEngine.AddGameResumedListener(gameEngine_GameResumed);
			GameEngine.Board.AddBoardUpdatedListener(board_BoardUpdated);
			m_PanelBoardActionsView.ActionButtonClick += actionButton_ActionButtonClick;

			try
			{
				GameEngine.Start();
				gameEngine_ActivePlayerChanged(GameEngine, GameEngine.ActivePlayer);
			}
			catch (GameEngineException e)
			{
				MessageBox.Show(e.Message, Resources.TextBoomerError, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void updatePlayerScore(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			m_LabelPlayer1Score.Text = string.Format(Resources.TextPlayerScore, i_GameEngine.Players[0].Name, i_GameEngine.Players[0].Score);
			m_LabelPlayer2Score.Text = string.Format(Resources.TextPlayerScore, i_GameEngine.Players[1].Name, i_GameEngine.Players[1].Score);
		}

		private void suspendUserInput()
		{
			m_PanelBoardActionsView.ActionButtonClick -= actionButton_ActionButtonClick;
		}

		private void resumeUserInput()
		{
			m_PanelBoardActionsView.ActionButtonClick += actionButton_ActionButtonClick;
		}

		private void doRestart()
		{
			GameEngine.Restart();
			m_PanelBoardView.Reset();
			m_PanelBoardActionsView.Reset();
		}

		private void makePlayerMove(object i_Sender)
		{
			suspendUserInput();

			try
			{
				if (GameEngine.ActivePlayer is IBot<eGameTool>)
				{
					MessageBox.Show(
						string.Format(Resources.TextNotYourTurn, GameEngine.ActivePlayer.Name),
						Resources.TextBoomerError,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
				else
				{
					try
					{
						// ReSharper disable once PossibleNullReferenceException
						int selectedColumn = int.Parse((i_Sender as ButtonBase).Text) - 1;
						Index location = GameEngine.MakePlayerMove(GameEngine.ActivePlayer, selectedColumn);
						if (location.Row == 0)
						{
							m_PanelBoardActionsView.Controls[location.Column].Enabled = false;
						}

						Application.DoEvents();

						if (!GameEngine.IsGameOver && GameEngine.OptionallyPlayPcMove(out location) && (location.Row == 0))
						{
							m_PanelBoardActionsView.Controls[location.Column].Enabled = false;
						}
					}
					catch (IllegalPlayerMoveException e)
					{
						MessageBox.Show(e.Message, Resources.TextBoomerError, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			finally
			{
				resumeUserInput();
			}
		}

		private void highlightActivePlayerScore(IPlayer<eGameTool> i_Player)
		{
			if (m_LabelPlayer1Score.Text.StartsWith(i_Player.Name))
			{
				m_LabelPlayer1Score.Font = new Font(m_LabelPlayer1Score.Font, FontStyle.Bold);
				m_LabelPlayer2Score.Font = new Font(m_LabelPlayer2Score.Font, FontStyle.Regular);
			}
			else
			{
				m_LabelPlayer1Score.Font = new Font(m_LabelPlayer1Score.Font, FontStyle.Regular);
				m_LabelPlayer2Score.Font = new Font(m_LabelPlayer2Score.Font, FontStyle.Bold);
			}
		}

		private void actionButton_ActionButtonClick(object i_Sender, EventArgs i_Args)
		{
			makePlayerMove(i_Sender);
		}

		private void gameEngine_ActivePlayerChanged(IBoardGameEngine<eGameTool> i_GameEngine, IPlayer<eGameTool> i_Player)
		{
			// Might be null when player undo the first move
			if (i_Player != null)
			{
				highlightActivePlayerScore(i_Player);
			}
		}

		private void gameEngine_GameStarted(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			// Call the other event so we will update status bar
			gameEngine_ActivePlayerChanged(i_GameEngine, i_GameEngine.ActivePlayer);
			updatePlayerScore(i_GameEngine);
			m_PanelBoardView.Reset();
			m_PanelBoardActionsView.Reset();
		}

		private void gameEngine_GameOver(IBoardGameEngine<eGameTool> i_GameEngine, IPlayer<eGameTool> i_Winner)
		{
			updatePlayerScore(i_GameEngine);

			string text = string.Format(
				@"{0}
{1}",
				i_Winner == null ? Resources.TextDraw : string.Format(Resources.TextWin, i_Winner.Name),
				Resources.TextAnotherRound);

			if (MessageBox.Show(text, Resources.TextGameOver, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				// Run it later to make sure PC turn has over. (We reach here during a player move)
				// Otherwise, we might disable a button after restarting the game.
				BeginInvoke(new Action(doRestart));
			}
			else
			{
				Close();
			}
		}

		private void gameEngine_GameResumed(IBoardGameEngine<eGameTool> i_GameEngine)
		{
			updatePlayerScore(i_GameEngine);
		}

		private void board_BoardUpdated(IBoard<eGameTool> i_Board, ICollection<Index> i_WinningFour)
		{
			m_PanelBoardView.Board = i_Board;
			m_PanelBoardView.Refresh(i_WinningFour);
		}

		private void buttonSwitchToMillennial_Click(object i_Sender, EventArgs i_Args)
		{
			Hide();

			FormConnectFourApplication formConnectFourApplication = new FormConnectFourApplication();
			formConnectFourApplication.FormClosed += formConnectFourApplication_FormClosed;

			formConnectFourApplication.ShowDialog();
		}

		private void formConnectFourApplication_FormClosed(object i_Sender, FormClosedEventArgs i_Args)
		{
			Close();
		}
	}
}