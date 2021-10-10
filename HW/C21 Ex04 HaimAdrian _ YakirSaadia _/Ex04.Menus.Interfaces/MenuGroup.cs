using System.Collections.Generic;
using Ex04.Menus.Common;

namespace Ex04.Menus.Interfaces
{
	public class MenuGroup : MenuItem, IMenuGroup
	{
		private readonly IList<IMenuItem> r_Items;

		public MenuGroup()
		{
			r_Items = new List<IMenuItem>();
		}

		public IList<IMenuItem> Items
		{
			get
			{
				return r_Items;
			}
		}
	}
}
