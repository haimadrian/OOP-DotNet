namespace C21_Ex02_Connect4Engine.Api.Game.Action
{
	public interface IActionKeeper
	{
		bool CanUndo { get; }

		bool CanRedo { get; }

		bool UndoLastMove();

		bool RedoLastMove();
	}
}