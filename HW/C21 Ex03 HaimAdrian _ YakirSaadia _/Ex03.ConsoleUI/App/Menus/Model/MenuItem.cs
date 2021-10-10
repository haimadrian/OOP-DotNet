using System;

namespace Ex03.ConsoleUI.App.Menus.Model
{
	internal class MenuItem<TMenuItem>
	{
		private readonly TMenuItem r_Item;

		private readonly string r_ItemText;

		private readonly Action<MenuItem<TMenuItem>> r_OnMenuItemChosen;

		public MenuItem(TMenuItem i_Item, string i_ItemText, Action<MenuItem<TMenuItem>> i_OnMenuItemChosen)
		{
			r_Item = i_Item;
			r_ItemText = i_ItemText;
			r_OnMenuItemChosen = i_OnMenuItemChosen;
		}

		public static bool operator ==(MenuItem<TMenuItem> i_Item1, MenuItem<TMenuItem> i_Item2)
		{
			return (ReferenceEquals(i_Item1, null) && ReferenceEquals(i_Item2, null)) || (!ReferenceEquals(i_Item1, null) && i_Item1.Equals(i_Item2));
		}

		public static bool operator !=(MenuItem<TMenuItem> i_Item1, MenuItem<TMenuItem> i_Item2)
		{
			return !(i_Item1 == i_Item2);
		}

		public TMenuItem Item
		{
			get
			{
				return r_Item;
			}
		}

		public string ItemText
		{
			get
			{
				return r_ItemText;
			}
		}

		public Action<MenuItem<TMenuItem>> OnMenuItemChosen
		{
			get
			{
				return r_OnMenuItemChosen;
			}
		}

		public override string ToString()
		{
			return string.Format("MenuItem={0}, ItemText={1}", Item.ToString(), ItemText);
		}

		public override bool Equals(object i_Another)
		{
			bool equals = false;

			MenuItem<TMenuItem> anotherMenuItem = i_Another as MenuItem<TMenuItem>;
			if (!ReferenceEquals(anotherMenuItem, null))
			{
				equals = Item.Equals(anotherMenuItem.Item);
			}

			return equals;
		}

		public override int GetHashCode()
		{
			// HashCode.Combine....
			int hash = 17;
			hash = (hash * 31) + Item.GetHashCode();

			return hash;
		}
	}
}
