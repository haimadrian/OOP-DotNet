using C21_Ex02_Connect4View.Menus;
using C21_Ex02_Connect4View.Views;
using C21_Ex02_Connect4Controller.Game.Engine;

namespace C21_Ex02_Connect4View
{
	internal class ConnectFourApplication
	{
		private bool m_IsRunning;
		private IBoardGameEngine<eGameTool> m_GameEngine;

		public bool IsRunning
		{
			get
			{
				return m_IsRunning;
			}

			set
			{
				m_IsRunning = value;
			}
		}

		private IBoardGameEngine<eGameTool> GameEngine
		{
			get
			{
				return m_GameEngine;
			}
		}

		public void Run()
		{
			IsRunning = true;

			if (createNewGame())
			{
				GameManager gameManager = new GameManager(GameEngine);
				gameManager.StartGame();

				while (IsRunning)
				{
					// Refresh returns true in case user selected to exit
					IsRunning = !gameManager.Refresh();
				}
			}
		}

		private bool createNewGame()
		{
			CreateNewGame createNewGame = new CreateNewGame();
			IsRunning = !createNewGame.ShowMenu(out m_GameEngine);
			return IsRunning;
		}
	}
}