using System.Collections.Generic;
using C21_Ex02_Connect4Engine.Api.Game.Action;
using C21_Ex02_Connect4Engine.Api.Game.Exceptions;
using C21_Ex02_Connect4Engine.Api.Game.Player;
using C21_Ex02_Connect4Engine.Core.Game.Action.Impl;
using C21_Ex02_Connect4Engine.Core.Game.Engine;

namespace C21_Ex02_Connect4Engine.Core.Game.Action
{
	internal class ActionExecutor<T> : IActionKeeper
	{
		private readonly Stack<IActionAny<T>> r_ActionsToUndo;
		private readonly Stack<IActionAny<T>> r_ActionsToRedo;

		public ActionExecutor()
		{
			r_ActionsToUndo = new Stack<IActionAny<T>>();
			r_ActionsToRedo = new Stack<IActionAny<T>>();
		}

		private Stack<IActionAny<T>> ActionsToUndo
		{
			get
			{
				return r_ActionsToUndo;
			}
		}

		private Stack<IActionAny<T>> ActionsToRedo
		{
			get
			{
				return r_ActionsToRedo;
			}
		}

		public bool CanUndo
		{
			get
			{
				return ActionsToUndo.Count > 0;
			}
		}

		public bool CanRedo
		{
			get
			{
				return ActionsToRedo.Count > 0;
			}
		}

		public void Clear()
		{
			ActionsToUndo.Clear();
			ActionsToRedo.Clear();
		}

		public TActionResult Execute<TActionResult>(eActionType i_ActionType, IInternalBoardGameEngine<T> i_GameEngine, IPlayer<T> i_Player, int? i_ColumnPlayed)
		{
			IActionAny<T> action = ActionFactory.NewAction<T>(i_ActionType);
			ActionContext<T> actionContext = new ActionContext<T>(this, i_GameEngine, i_Player, i_ColumnPlayed);

			if (!action.IsEnabled(actionContext))
			{
				throw new GameEngineException(string.Format("Cannot execute {0}. This action is not enabled.", i_ActionType.ToString()));
			}

			TActionResult actionResult = (TActionResult)action.Execute(actionContext);
			ActionsToUndo.Push(action);
			ActionsToRedo.Clear();

			return actionResult;
		}

		public bool UndoLastMove()
		{
			bool isUndone = false;

			if (CanUndo)
			{
				IActionAny<T> action = ActionsToUndo.Pop();
				action.Undo();
				ActionsToRedo.Push(action);
				isUndone = true;
			}

			return isUndone;
		}

		public bool RedoLastMove()
		{
			bool isRedone = false;

			if (CanRedo)
			{
				IActionAny<T> action = ActionsToRedo.Pop();
				action.Redo();
				ActionsToUndo.Push(action);
				isRedone = true;
			}

			return isRedone;
		}
	}
}
