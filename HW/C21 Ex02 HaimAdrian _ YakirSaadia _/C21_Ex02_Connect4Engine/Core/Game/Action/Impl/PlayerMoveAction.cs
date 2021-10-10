using System.Collections.Generic;
using C21_Ex02_Connect4Engine.Api.Game.Exceptions;
using C21_Ex02_Connect4Engine.Api.Game.Player;
using C21_Ex02_Connect4Engine.Api.Matrix;

namespace C21_Ex02_Connect4Engine.Core.Game.Action.Impl
{
	internal class PlayerMoveAction<TGameToolType> : AAction<TGameToolType, Index>
	{
		private const int k_DifferenceBetweenUserColumnToBoardColumn = 1;

		private Index m_PlayerMove;
		private Index m_LastPlayerMove;
		private IPlayer<TGameToolType> m_Player;
		private IPlayer<TGameToolType> m_LastPlayer;
		private int m_ColumnPlayed;
		private bool m_HasWon;

		protected override Index DoExecute(ActionContext<TGameToolType> i_Context)
		{
			m_LastPlayerMove = GameEngine.LastPlayerMove;
			m_LastPlayer = GameEngine.LastActivePlayer;
			m_Player = i_Context.Player;
			m_ColumnPlayed = i_Context.ColumnPlayed;

			if (!GameEngine.TryMakePlayerMove(m_Player, i_Context.ColumnPlayed, out m_PlayerMove))
			{
				throw new IllegalPlayerMoveException(
					string.Format("Unable to play at {0}. Column is full.", i_Context.ColumnPlayed + k_DifferenceBetweenUserColumnToBoardColumn));
			}

			// In case player won, we will need to remove 1 point from its score during undo of the win.
			ICollection<Index> ignore;
			m_HasWon = GameEngine.HasWinner(out ignore);

			return m_PlayerMove;
		}

		public override void Undo()
		{
			if (m_HasWon)
			{
				m_Player.Score--;
			}

			// Do it twice so we will set the last player and active player
			GameEngine.ActivePlayer = m_LastPlayer;
			GameEngine.ActivePlayer = m_Player;

			GameEngine.LastPlayerMove = m_LastPlayerMove;
			GameEngine.Board.RemoveGameTool(m_ColumnPlayed);
		}

		public override void Redo()
		{
			Index ignore;
			GameEngine.TryMakePlayerMove(m_Player, m_ColumnPlayed, out ignore);
		}

		protected override bool IsActionEnabled(ActionContext<TGameToolType> i_Context)
		{
			return (GameEngine.ActivePlayer != null) && GameEngine.ActivePlayer.Equals(i_Context.Player);
		}
	}
}