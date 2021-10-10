using Ex02.Connect4Engine.Core.Game.Engine;

namespace Ex02.Connect4Engine.Core.Game.Action.Impl
{
	internal abstract class AAction<TGameToolType, TActionResult> : IActionAny<TGameToolType>
	{
		private const bool k_ActionEnabledDefault = true;

		private ActionExecutor<TGameToolType> m_ActionExecutor;
		private IInternalBoardGameEngine<TGameToolType> m_GameEngine;

		protected ActionExecutor<TGameToolType> ActionExecutor
		{
			get
			{
				return m_ActionExecutor;
			}

			private set
			{
				m_ActionExecutor = value;
			}
		}

		protected IInternalBoardGameEngine<TGameToolType> GameEngine
		{
			get
			{
				return m_GameEngine;
			}

			private set
			{
				m_GameEngine = value;
			}
		}

		public bool IsEnabled(ActionContext<TGameToolType> i_Context)
		{
			backupContext(i_Context);
			return IsActionEnabled(i_Context);
		}

		public TActionResult Execute(ActionContext<TGameToolType> i_Context)
		{
			backupContext(i_Context);
			return DoExecute(i_Context);
		}

		public abstract void Undo();

		public abstract void Redo();

		protected abstract TActionResult DoExecute(ActionContext<TGameToolType> i_Context);

		object IActionAny<TGameToolType>.Execute(ActionContext<TGameToolType> i_Context)
		{
			return Execute(i_Context);
		}

		protected virtual bool IsActionEnabled(ActionContext<TGameToolType> i_Context)
		{
			return k_ActionEnabledDefault;
		}

		private void backupContext(ActionContext<TGameToolType> i_Context)
		{
			ActionExecutor = i_Context.ActionExecutor;
			GameEngine = i_Context.GameEngine;
		}
	}
}