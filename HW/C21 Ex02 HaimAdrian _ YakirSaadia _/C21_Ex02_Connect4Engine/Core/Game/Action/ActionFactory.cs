using System;
using C21_Ex02_Connect4Engine.Core.Game.Action.Impl;

namespace C21_Ex02_Connect4Engine.Core.Game.Action
{
	internal static class ActionFactory
	{
		public static IActionAny<TGameToolType> NewAction<TGameToolType>(eActionType i_ActionType)
		{
			IActionAny<TGameToolType> action;

			switch (i_ActionType)
			{
				case eActionType.PlayerMove:
					action = new PlayerMoveAction<TGameToolType>();
					break;
				default:
					throw new ArgumentOutOfRangeException("i_ActionType", i_ActionType, null);
			}

			return action;
		}
	}
}