namespace Ex02.Connect4Engine.Core.Game.Action.Impl
{
	internal interface IActionAny<TGameToolType>
	{
		bool IsEnabled(ActionContext<TGameToolType> i_Context);

		// Created to fake Java's <?>, cause I needed to keep actions in Stack, where I do not have
		// the generic return type of an action... -> Casting
		object Execute(ActionContext<TGameToolType> i_Context);

		void Undo();

		void Redo();
	}
}