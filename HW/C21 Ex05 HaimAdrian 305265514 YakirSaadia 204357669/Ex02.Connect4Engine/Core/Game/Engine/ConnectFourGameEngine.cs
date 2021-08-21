using System;
using System.Collections.Generic;
using Ex02.Connect4Engine.Api.Game.Board;
using Ex02.Connect4Engine.Api.Game.Engine;
using Ex02.Connect4Engine.Api.Game.Exceptions;
using Ex02.Connect4Engine.Api.Game.Player;
using Ex02.Connect4Engine.Api.Matrix;
using Ex02.Connect4Engine.Api.System;
using Ex02.Connect4Engine.Core.Game.Action;
using Ex02.Connect4Engine.Core.Game.Board;

namespace Ex02.Connect4Engine.Core.Game.Engine
{
	internal class ConnectFourGameEngine<T> : IInternalBoardGameEngine<T>
	{
		private const int k_AmountOfToolsToConnectInARow = 4;
		private const int k_AmountOfPlayers = 2;

		private readonly ActionExecutor<T> r_ActionExecutor;
		private readonly ConnectBoard<T> r_Board;
		private readonly List<IPlayer<T>> r_Players;
		private IPlayer<T> m_ActivePlayer;
		private IPlayer<T> m_LastActivePlayer;
		private IPlayer<T> m_StartingPlayer;
		private IBot<T> m_Bot;
		private Index m_LastPlayerMove;
		private bool m_IsGameOver;

		public event Action<IBoardGameEngine<T>, IPlayer<T>> ActivePlayerChanged;

		public event Action<IBoardGameEngine<T>> GameStarted;

		public event Action<IBoardGameEngine<T>, IPlayer<T>> GameOver;

		// When game is over and player selects undo
		public event Action<IBoardGameEngine<T>> GameResumed;

		public ConnectFourGameEngine(int i_Rows, int i_Columns)
		{
			r_ActionExecutor = new ActionExecutor<T>();
			r_Board = new ConnectBoard<T>(i_Rows, i_Columns, k_AmountOfToolsToConnectInARow);
			r_Players = new List<IPlayer<T>>(k_AmountOfPlayers);
		}

		private ActionExecutor<T> ActionExecutor
		{
			get
			{
				return r_ActionExecutor;
			}
		}

		public IBoard<T> Board
		{
			get
			{
				return r_Board;
			}
		}

		public List<IPlayer<T>> Players
		{
			get
			{
				return r_Players;
			}
		}

		public IPlayer<T> ActivePlayer
		{
			get
			{
				return m_ActivePlayer;
			}

			set
			{
				LastActivePlayer = m_ActivePlayer;
				m_ActivePlayer = value;

				OnActivePlayerChanged();
			}
		}

		public IPlayer<T> LastActivePlayer
		{
			get
			{
				return m_LastActivePlayer;
			}

			set
			{
				m_LastActivePlayer = value;
			}
		}

		public Index LastPlayerMove
		{
			get
			{
				return m_LastPlayerMove;
			}

			set
			{
				m_LastPlayerMove = value;
			}
		}

		public bool CanUndo
		{
			get
			{
				return ActionExecutor.CanUndo;
			}
		}

		public bool CanRedo
		{
			get
			{
				return ActionExecutor.CanRedo;
			}
		}

		public bool IsGameOver
		{
			get
			{
				return m_IsGameOver;
			}

			private set
			{
				m_IsGameOver = value;
			}
		}

		public bool AddPlayer(IPlayer<T> i_Player)
		{
			bool add = true;

			if (Players.Count < k_AmountOfPlayers)
			{
				foreach (IPlayer<T> currentPlayer in Players)
				{
					if (currentPlayer.Equals(i_Player))
					{
						add = false;
						break;
					}
				}
			}
			else
			{
				add = false;
			}

			if (add)
			{
				Players.Add(i_Player);

				IBot<T> bot = i_Player as IBot<T>;
				if (bot != null)
				{
					m_Bot = bot;
					ActivePlayer = selectOtherPlayer(m_Bot);
				}
				else if ((m_Bot != null) && (ActivePlayer == null))
				{
					ActivePlayer = i_Player;
				}
			}

			return add;
		}

		public void Start()
		{
			if (Players.Count != k_AmountOfPlayers)
			{
				throw new GameEngineException(string.Format("Missing players. Expectation: {0}, Actual: {1}", k_AmountOfPlayers, Players.Count));
			}

			if (ActivePlayer == null)
			{
				throw new GameEngineException("Cannot start a game before active player is set.");
			}

			m_StartingPlayer = ActivePlayer;
			IsGameOver = false;
			Board.Clear();
			OnGameStarted();
		}

		public void Restart()
		{
			ActivePlayer = m_StartingPlayer;
			LastPlayerMove = default(Index);
			IsGameOver = false;
			Board.Clear();
			ActionExecutor.Clear();
			OnGameStarted();
		}

		public Index MakePlayerMove(IPlayer<T> i_Player, int i_Column)
		{
			if (m_StartingPlayer == null)
			{
				throw new GameEngineException("You must start a game before trying to play.");
			}

			return ActionExecutor.Execute<Index>(eActionType.PlayerMove, this, i_Player, i_Column);
		}

		public bool TryMakePlayerMove(IPlayer<T> i_Player, int i_Column, out Index o_Move)
		{
			if (m_StartingPlayer == null)
			{
				throw new GameEngineException("You must start a game before trying to play.");
			}

			if (IsGameOver)
			{
				throw new IllegalPlayerMoveException("Game is over. Please restart.");
			}

			bool successfulMove = false;

			if (Board.TryAddGameTool(i_Column, i_Player.GameTool, out o_Move))
			{
				LastPlayerMove = o_Move;
				successfulMove = true;
				moveTurnToNextPlayer();
				checkGameOver();
			}

			return successfulMove;
		}

		public bool OptionallyPlayPcMove(out Index o_Move)
		{
			bool successfulMove = false;
			o_Move = default(Index);

			IBot<T> bot = ActivePlayer as IBot<T>;
			if (bot != null)
			{
				successfulMove = true;
				LastPlayerMove = bot.MakeMove(this);
				o_Move = LastPlayerMove;
			}

			return successfulMove;
		}

		public void AddActivePlayerChangedListener(Action<IBoardGameEngine<T>, IPlayer<T>> i_Listener)
		{
			ActivePlayerChanged += i_Listener;
		}

		public void AddGameStartedListener(Action<IBoardGameEngine<T>> i_Listener)
		{
			GameStarted += i_Listener;
		}

		public void AddGameOverListener(Action<IBoardGameEngine<T>, IPlayer<T>> i_Listener)
		{
			GameOver += i_Listener;
		}

		public void AddGameResumedListener(Action<IBoardGameEngine<T>> i_Listener)
		{
			GameResumed += i_Listener;
		}

		public bool UndoLastMove()
		{
			bool wasGameOver = IsGameOver;
			bool isUndone = ActionExecutor.UndoLastMove();

			// Detect if undo last move, cause we might update winner score, and we would like to reflect that.
			if (wasGameOver && isUndone)
			{
				IsGameOver = false;
				ActivePlayer.Score--;
				OnGameResumed();
			}

			return isUndone;
		}

		public bool RedoLastMove()
		{
			return ActionExecutor.RedoLastMove();
		}

		protected virtual void OnActivePlayerChanged()
		{
			if (ActivePlayerChanged != null)
			{
				ActivePlayerChanged.Invoke(this, ActivePlayer);
			}
		}

		protected virtual void OnGameStarted()
		{
			if (GameStarted != null)
			{
				GameStarted.Invoke(this);
			}
		}

		protected virtual void OnGameOver(IPlayer<T> i_Winner)
		{
			if (GameOver != null)
			{
				GameOver.Invoke(this, i_Winner);
			}
		}

		protected virtual void OnGameResumed()
		{
			if (GameResumed != null)
			{
				GameResumed.Invoke(this);
			}
		}

		private void checkGameOver()
		{
			if (LastPlayerMove.IsValid)
			{
				ICollection<Index> ignore;
				IsGameOver = Board.OptionallyEvaluateWinner(LastPlayerMove, out ignore);

				if (IsGameOver)
				{
					LastActivePlayer.Score++;
					OnGameOver(LastActivePlayer);
				}
				else if (Board.IsBoardFull)
				{
					IsGameOver = true;
					OnGameOver(null);
				}
			}
			else
			{
				IsGameOver = false;
			}
		}

		private void moveTurnToNextPlayer()
		{
			ActivePlayer = selectOtherPlayer(ActivePlayer);
		}

		private IPlayer<T> selectOtherPlayer(IPlayer<T> i_OppositeToPlayer)
		{
			IPlayer<T> selectedPlayer = null;

			foreach (IPlayer<T> currentPlayer in Players)
			{
				if (!currentPlayer.Equals(i_OppositeToPlayer))
				{
					selectedPlayer = currentPlayer;
					break;
				}
			}

			return selectedPlayer;
		}
	}
}