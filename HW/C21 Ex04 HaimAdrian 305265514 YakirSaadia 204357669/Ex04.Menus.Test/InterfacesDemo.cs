using Ex04.ConsoleMenu;
using Ex04.Menus.Common;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Interfaces.Observer;

namespace Ex04.Menus.Test
{
	internal sealed class InterfacesDemo : IDemo
	{
		private readonly MainMenu r_MainMenu = new MainMenu("Interfaces Demo");

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
			menuItem.MenuItemSelected += new CountSpacesObserver();
			menuGroup.Items.Add(menuItem);

			menuItem = new MenuItem();
			menuItem.Caption = "Show Version";
			menuItem.MenuItemSelected += new ShowVersionObserver();
			menuGroup.Items.Add(menuItem);

			r_MainMenu.AddMenuItem(menuGroup);
		}

		private void initDateTimeMenuGroup()
		{
			IMenuGroup menuGroup = new MenuGroup();
			menuGroup.Caption = "Show Date/Time";

			MenuItem menuItem = new MenuItem();
			menuItem.Caption = "Show Date";
			menuItem.MenuItemSelected += new ShowDateObserver();
			menuGroup.Items.Add(menuItem);

			menuItem = new MenuItem();
			menuItem.Caption = "Show Time";
			menuItem.MenuItemSelected += new ShowTimeObserver();
			menuGroup.Items.Add(menuItem);

			r_MainMenu.AddMenuItem(menuGroup);
		}

		private sealed class CountSpacesObserver : IObserver<IMenuItem>
		{
			public void Update(IMenuItem i_Subject)
			{
				SystemMethods.CountSpaces();
			}
		}

		private sealed class ShowVersionObserver : IObserver<IMenuItem>
		{
			public void Update(IMenuItem i_Subject)
			{
				SystemMethods.ShowVersion();
			}
		}

		private sealed class ShowDateObserver : IObserver<IMenuItem>
		{
			public void Update(IMenuItem i_Subject)
			{
				SystemMethods.ShowDate();
			}
		}

		private sealed class ShowTimeObserver : IObserver<IMenuItem>
		{
			public void Update(IMenuItem i_Subject)
			{
				SystemMethods.ShowTime();
			}
		}
	}
}