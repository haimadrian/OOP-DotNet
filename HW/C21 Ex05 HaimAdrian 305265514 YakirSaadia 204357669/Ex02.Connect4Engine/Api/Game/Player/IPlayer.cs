namespace Ex02.Connect4Engine.Api.Game.Player
{
	public interface IPlayer<T>
	{
		string Id { get; }

		string Name { get; set; }

		T GameTool { get; set; }

		int Score { get; set; }
	}
}