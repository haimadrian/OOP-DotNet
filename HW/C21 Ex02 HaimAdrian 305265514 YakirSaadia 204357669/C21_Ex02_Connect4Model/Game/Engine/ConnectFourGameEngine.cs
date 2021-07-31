using System.Collections.Generic;
using C21_Ex02_Connect4Controller.Game.Board;
using C21_Ex02_Connect4Controller.Game.Engine;
using C21_Ex02_Connect4Controller.Game.Exceptions;
using C21_Ex02_Connect4Controller.Game.Player;
using C21_Ex02_Connect4Controller.Matrix;
using C21_Ex02_Connect4Model.Game.Board;

namespace C21_Ex02_Connect4Model.Game.Engine
{
	public class ConnectFourGameEngine<T> : IBoardGameEngine<T>
	{
		private const int k_AmountOfToolsToConnectInARow = 4;
		private const int k_AmountOfPlayers = 2;

		private readonly ConnectBoard<T> r_Board;
		private readonly List<IPlayer<T>> r_Players;
		private IPlayer<T> m_ActivePlayer;
		private IPlayer<T> m_LastActivePlayer;
		private IPlayer<T> m_StartingPlayer;
		private IBot<T> m_Bot;

		public ConnectFourGameEngine(int i_Rows, int i_Columns)
		{
			r_Board = new ConnectBoard<T>(i_Rows, i_Columns, k_AmountOfToolsToConnectInARow);
			r_Players = new List<IPlayer<T>>(k_AmountOfPlayers);
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
			Board.Clear();
		}

		public void Restart()
		{
			ActivePlayer = m_StartingPlayer;
			Board.Clear();
		}

		public Index MakePlayerMove(IPlayer<T> i_Player, int i_Column, out ICollection<Index> o_GameToolsInARow)
		{
			if (m_StartingPlayer == null)
			{
				throw new GameEngineException("You must start a game before trying to play.");
			}

			Index selectedCell = Board.AddGameTool(i_Column, i_Player.GameTool);

			Board.OptionallyEvaluateWinner(selectedCell, out o_GameToolsInARow);
			moveTurnToNextPlayer();

			return selectedCell;
		}

		public bool TryMakePlayerMove(IPlayer<T> i_Player, int i_Column, out ICollection<Index> o_GameToolsInARow, out Index o_Move)
		{
			if (m_StartingPlayer == null)
			{
				throw new GameEngineException("You must start a game before trying to play.");
			}

			bool successfulMove = false;
			o_GameToolsInARow = null;
			
			if (Board.TryAddGameTool(i_Column, i_Player.GameTool, out o_Move))
			{
				successfulMove = true;
				Board.OptionallyEvaluateWinner(o_Move, out o_GameToolsInARow);
				moveTurnToNextPlayer();
			}

			return successfulMove;
		}

		public bool OptionallyPlayPcMove(out ICollection<Index> o_GameToolsInARow, out Index o_Move)
		{
			bool successfulMove = false;
			o_GameToolsInARow = null;
			o_Move = default(Index);

			IBot<T> bot = ActivePlayer as IBot<T>;
			if (bot != null)
			{
				successfulMove = true;
				o_Move = bot.MakeMove(this, out o_GameToolsInARow);
			}

			return successfulMove;
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