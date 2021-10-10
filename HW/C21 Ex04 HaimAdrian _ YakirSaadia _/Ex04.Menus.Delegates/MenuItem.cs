using System;
using Ex04.Menus.Common;

namespace Ex04.Menus.Delegates
{
	public class MenuItem : AMenuItem
	{
		public event Action<IMenuItem> MenuItemSelected; 

		public override void OnMenuItemSelected()
		{
			if (MenuItemSelected != null)
			{
				MenuItemSelected.Invoke(this);
			}
		}
	}
}
