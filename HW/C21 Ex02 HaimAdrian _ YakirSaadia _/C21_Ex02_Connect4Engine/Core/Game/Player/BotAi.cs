using System;
using System.Collections.Generic;
using C21_Ex02_Connect4Engine.Api.Game.Board;
using C21_Ex02_Connect4Engine.Api.Game.Engine;
using C21_Ex02_Connect4Engine.Api.Game.Player;
using C21_Ex02_Connect4Engine.Api.Matrix;

namespace C21_Ex02_Connect4Engine.Core.Game.Player
{
	internal class BotAi<T> : Player<T>, IBot<T>
	{
		private const string k_PlayerId = "AI";
		private const int k_DecisionTreeDepthPerAiLevel = 2;

		private readonly Random r_MultipleBestScoresRandom;
		private readonly int r_DepthOfDecisionTree;

		private IPlayer<T> m_OtherPlayer;

		public BotAi(eAiLevel i_AiLevel) : base(k_PlayerId, k_PlayerId)
		{
			r_MultipleBestScoresRandom = new Random();
			r_DepthOfDecisionTree = k_DecisionTreeDepthPerAiLevel * (int)i_AiLevel;

			Name = i_AiLevel.ToString();
		}

		public Index MakeMove(IBoardGameEngine<T> i_GameEngine)
		{
			findOtherPlayerIfNotFoundAlready(i_GameEngine);
			int selectedColumn = selectBestMove(i_GameEngine);

			return i_GameEngine.MakePlayerMove(this, selectedColumn);
		}

		private int selectBestMove(IBoardGameEngine<T> i_GameEngine)
		{
			Dictionary<int, int> columnToScore = new Dictionary<int, int>();
			for (int currentColumn = 0; currentColumn < i_GameEngine.Board.Columns; currentColumn++)
			{
				Index successfulMove;
				if (i_GameEngine.Board.TryAddGameTool(currentColumn, GameTool, out successfulMove))
				{
					columnToScore.Add(currentColumn, miniMaxAlgorithm(i_GameEngine.Board, successfulMove, false, r_DepthOfDecisionTree));
					i_GameEngine.Board.RemoveGameTool(currentColumn);
				}
			}

			// Why not Linq...? :(
			List<int> selectedColumns = new List<int>();
			int bestScore = int.MinValue;
			foreach (KeyValuePair<int, int> currentEntry in columnToScore)
			{
				int absoluteValue = currentEntry.Value;
				if (absoluteValue > bestScore)
				{
					bestScore = absoluteValue;
					selectedColumns.Clear();
				}

				if (absoluteValue == bestScore)
				{
					selectedColumns.Add(currentEntry.Key);
				}
			}

			// When there are several options (several "best" scores), randomly select a column.
			return selectedColumns[r_MultipleBestScoresRandom.Next(selectedColumns.Count)];
		}

		private void findOtherPlayerIfNotFoundAlready(IBoardGameEngine<T> i_GameEngine)
		{
			if (m_OtherPlayer == null)
			{
				foreach (IPlayer<T> currentPlayer in i_GameEngine.Players)
				{
					if (!currentPlayer.Equals(this))
					{
						m_OtherPlayer = currentPlayer;
						break;
					}
				}
			}
		}

		private int miniMaxAlgorithm(IBoard<T> i_Board, Index i_LastMove, bool i_MaximizingPlayer, int i_Depth)
		{
			int score = 0;

			if (i_Depth > 0)
			{
				ICollection<Index> winIndices;
				if (i_Board.OptionallyEvaluateWinner(i_LastMove, out winIndices))
				{
					using(IEnumerator<Index> winIndicesEnumerator = winIndices.GetEnumerator())
					{
						winIndicesEnumerator.MoveNext();

						// When the winner is the AI (this player), get the result as maximizing player
						if (GameTool.Equals(i_Board[winIndicesEnumerator.Current]))
						{
							score = i_Depth;
						}
						else
						{
							// Otherwise, this is the minimizing player
							score = -i_Depth;
						}
					}
				}
				else if (!i_Board.IsBoardFull)
				{
					score = i_MaximizingPlayer ? -1 : 1;
					for (int currentColumn = 0; currentColumn < i_Board.Columns; currentColumn++)
					{
						Index successfulMove;
						if (i_Board.TryAddGameTool(currentColumn, i_MaximizingPlayer ? GameTool : m_OtherPlayer.GameTool, out successfulMove))
						{
							int v = miniMaxAlgorithm(i_Board, successfulMove, !i_MaximizingPlayer, i_Depth - 1);
							score = i_MaximizingPlayer ? Math.Max(score, v) : Math.Min(score, v);
							i_Board.RemoveGameTool(currentColumn);
						}
					}
				}
			}

			return score;
		}
	}
}
