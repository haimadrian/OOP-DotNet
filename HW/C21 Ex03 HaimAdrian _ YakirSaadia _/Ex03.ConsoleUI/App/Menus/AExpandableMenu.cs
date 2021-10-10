using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI.App.Menus
{
	internal abstract class AExpandableMenu<TMenuItem> : AMenu<TMenuItem>
	{
		private readonly IDictionary<TMenuItem, object> r_ExpandedMenus;

		protected AExpandableMenu()
		{
			r_ExpandedMenus = new Dictionary<TMenuItem, object>();
		}

		protected static void DoBeforeMenu()
		{
			Console.Clear();
		}

		protected static void DoAfterMenu()
		{
			Console.WriteLine("{0}Press Enter to go back to main menu...", Environment.NewLine);
			Console.ReadLine();
		}

		protected TMenuType ComputeExpandedMenuIfMissing<TMenuType>(TMenuItem i_MenuItem)
		{
			if (!r_ExpandedMenus.ContainsKey(i_MenuItem))
			{
				r_ExpandedMenus[i_MenuItem] = Activator.CreateInstance(typeof(TMenuType));
			}

			return (TMenuType)r_ExpandedMenus[i_MenuItem];
		}
	}
}
