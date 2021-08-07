using Ex03.ConsoleUI.App.Menus.Model;

namespace Ex03.ConsoleUI.App.Menus
{
	internal abstract class AMenu<TMenuItem>
	{
		private readonly MenuItemGroup<TMenuItem> r_MenuItemGroup;
		private readonly ConsoleMenuManager<TMenuItem> r_ConsoleMenuManager;

		protected AMenu()
		{
			r_MenuItemGroup = new MenuItemGroup<TMenuItem>();

			// ReSharper disable once VirtualMemberCallInConstructor
			r_ConsoleMenuManager = new ConsoleMenuManager<TMenuItem>(MenuTitle, r_MenuItemGroup);

			// ReSharper disable once VirtualMemberCallInConstructor
			InitMenuItems();
		}

		protected MenuItemGroup<TMenuItem> MenuItemGroup
		{
			get
			{
				return r_MenuItemGroup;
			}
		}

		protected abstract string MenuTitle { get; }

		protected abstract void InitMenuItems();

		protected TMenuItem Show(bool i_ClearConsole)
		{
			return r_ConsoleMenuManager.Show(i_ClearConsole);
		}
	}
}