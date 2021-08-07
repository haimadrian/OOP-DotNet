using System;
using System.Text;
using Ex03.ConsoleUI.App.Menus.Model;
using Ex03.UserInputUtils;

namespace Ex03.ConsoleUI.App.Menus
{
	internal class ConsoleMenuManager<TMenuItem>
	{
		private const int k_MinChoice = 1;

		private readonly string r_Title;
		private readonly MenuItemGroup<TMenuItem> r_MenuItemGroup;

		public ConsoleMenuManager(string i_Title, MenuItemGroup<TMenuItem> i_MenuItemGroup)
		{
			r_Title = i_Title;
			r_MenuItemGroup = i_MenuItemGroup;
		}

		public MenuItemGroup<TMenuItem> MenuItemGroup
		{
			get
			{
				return r_MenuItemGroup;
			}
		}

		public TMenuItem Show(bool i_ShouldClearConsole)
		{
			if (i_ShouldClearConsole)
			{
				Console.Clear();
			}

			printMenu();

			string userInput = ConsoleReader.ReadUserInputWithValidation(string.Empty, isUserChoiceValid);
			int userChoice = int.Parse(userInput);

			MenuItem<TMenuItem> selectedMenuItem = MenuItemGroup[userChoice - 1];
			OnMenuItemChosen(selectedMenuItem);

			return selectedMenuItem.Item;
		}

		protected virtual void OnMenuItemChosen(MenuItem<TMenuItem> i_ChosenMenuItem)
		{
			if (i_ChosenMenuItem.OnMenuItemChosen != null)
			{
				i_ChosenMenuItem.OnMenuItemChosen.Invoke(i_ChosenMenuItem);
			}
		}

		private void printMenu()
		{
			StringBuilder menu = new StringBuilder();

			if (!string.IsNullOrEmpty(r_Title))
			{
				menu.AppendLine(r_Title).AppendLine();
			}

			menu.AppendLine("Please select one of the choices below:");

			foreach (MenuItem<TMenuItem> currentMenuItem in MenuItemGroup)
			{
				string menuItemText = string.IsNullOrEmpty(currentMenuItem.ItemText) ? currentMenuItem.Item.ToString() : currentMenuItem.ItemText;
				menu.Append(MenuItemGroup.IndexOf(currentMenuItem) + 1).Append(". ").AppendLine(menuItemText);
			}

			Console.WriteLine(menu.ToString());
		}

		private bool isUserChoiceValid(string i_InputString)
		{
			int choice;
			return !string.IsNullOrEmpty(i_InputString) &&
				   int.TryParse(i_InputString, out choice) &&
				   (choice >= k_MinChoice) &&
				   (choice <= MenuItemGroup.Count);
		}
	}
}