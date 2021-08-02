namespace C21_Ex02_Connect4Engine.Api.Game.Player
{
	public interface IPlayer<T>
	{
		string Id { get; }

		string Name { get; set; }

		T GameTool { get; set; }

		int Score { get; set; }
	}
}