using Ex04.ConsoleMenu;
using Ex04.Menus.Common;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
	internal sealed class DelegatesDemo : IDemo
	{
		private readonly MainMenu r_MainMenu = new MainMenu("Delegates Demo");

		private static void countSpacesMenuItem_Selected(IMenuItem i_MenuItem)
		{
			SystemMethods.CountSpaces();
		}

		private static void showVersionMenuItem_Selected(IMenuItem i_MenuItem)
		{
			SystemMethods.ShowVersion();
		}

		private static void showDateMenuItem_Selected(IMenuItem i_MenuItem)
		{
			SystemMethods.ShowDate();
		}

		private static void showTimeMenuItem_Selected(IMenuItem i_MenuItem)
		{
			SystemMethods.ShowTime();
		}

		public void Init()
		{
			initVersionAndSpacesMenuGroup();
			initDateTimeMenuGroup();
		}

		public void Show()
		{
			r_MainMenu.Show();
		}

		private void initVersionAndSpacesMenuGroup()
		{
			IMenuGroup menuGroup = new MenuGroup();
			menuGroup.Caption = "Version and Spaces";

			MenuItem menuItem = new MenuItem();
			menuItem.Caption = "Count Spaces";
			menuItem.MenuItemSelected += countSpacesMenuItem_Selected;
			menuGroup.Items.Add(menuItem);

			menuItem = new MenuItem();
			menuItem.Caption = "Show Version";
			menuItem.MenuItemSelected += showVersionMenuItem_Selected;
			menuGroup.Items.Add(menuItem);

			r_MainMenu.AddMenuItem(menuGroup);
		}

		private void initDateTimeMenuGroup()
		{
			IMenuGroup menuGroup = new MenuGroup();
			menuGroup.Caption = "Show Date/Time";

			MenuItem menuItem = new MenuItem();
			menuItem.Caption = "Show Date";
			menuItem.MenuItemSelected += showDateMenuItem_Selected;
			menuGroup.Items.Add(menuItem);

			menuItem = new MenuItem();
			menuItem.Caption = "Show Time";
			menuItem.MenuItemSelected += showTimeMenuItem_Selected;
			menuGroup.Items.Add(menuItem);

			r_MainMenu.AddMenuItem(menuGroup);
		}
	}
}