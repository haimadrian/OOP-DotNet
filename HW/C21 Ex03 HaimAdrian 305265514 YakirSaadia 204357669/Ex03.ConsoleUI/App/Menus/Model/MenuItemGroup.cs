using System.Collections;
using System.Collections.Generic;

namespace Ex03.ConsoleUI.App.Menus.Model
{
	internal class MenuItemGroup<TKey> : ICollection<MenuItem<TKey>>
	{
		private readonly IList<MenuItem<TKey>> r_MenuItems;
		private readonly IDictionary<TKey, int> r_MenuItemToIndex;

		public MenuItemGroup()
		{
			r_MenuItems = new List<MenuItem<TKey>>();
			r_MenuItemToIndex = new Dictionary<TKey, int>();
		}

		private IList<MenuItem<TKey>> MenuItems
		{
			get
			{
				return r_MenuItems;
			}
		}

		public int Count
		{
			get
			{
				return MenuItems.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return MenuItems.IsReadOnly;
			}
		}

		public MenuItem<TKey> this[int i_Index]
		{
			get
			{
				return MenuItems[i_Index];
			}
		}

		public MenuItem<TKey> this[TKey i_Item]
		{
			get
			{
				return this[IndexOf(i_Item)];
			}
		}

		public IEnumerator<MenuItem<TKey>> GetEnumerator()
		{
			return MenuItems.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(MenuItem<TKey> i_Item)
		{
			if ((i_Item != null) && !r_MenuItemToIndex.ContainsKey(i_Item.Item))
			{
				MenuItems.Add(i_Item);
				r_MenuItemToIndex[i_Item.Item] = MenuItems.Count - 1;
			}
		}

		public void Add(TKey i_Item, string i_ItemText, MenuItem<TKey>.MenuItemChosenEventHandler i_OnMenuItemChosen)
		{
			Add(new MenuItem<TKey>(i_Item, i_ItemText, i_OnMenuItemChosen));
		}

		public int IndexOf(MenuItem<TKey> i_Item)
		{
			int index = -1;

			if (i_Item != null)
			{
				index = IndexOf(i_Item.Item);
			}

			return index;
		}

		public int IndexOf(TKey i_Item)
		{
			int index = -1;

			if (Contains(i_Item))
			{
				index = r_MenuItemToIndex[i_Item];
			}

			return index;
		}

		public void Clear()
		{
			MenuItems.Clear();
			r_MenuItemToIndex.Clear();
		}

		public bool Contains(MenuItem<TKey> i_Item)
		{
			bool contains = false;

			if (i_Item != null)
			{
				contains = Contains(i_Item.Item);
			}

			return contains;
		}

		public bool Contains(TKey i_Item)
		{
			return r_MenuItemToIndex.ContainsKey(i_Item);
		}

		public void CopyTo(MenuItem<TKey>[] i_Array, int i_ArrayIndex)
		{
			MenuItems.CopyTo(i_Array, i_ArrayIndex);
		}

		public bool Remove(MenuItem<TKey> i_Item)
		{
			bool removed = false;

			if (i_Item != null)
			{
				removed = Remove(i_Item.Item);
			}

			return removed;
		}

		public bool Remove(TKey i_Item)
		{
			bool removed = false;

			if (Contains(i_Item))
			{
				removed = true;
				int itemIndex = IndexOf(i_Item);
				r_MenuItemToIndex.Remove(i_Item);
				MenuItems[itemIndex] = null;
			}

			return removed;
		}

		public void RemoveAt(int i_Index)
		{
			if ((i_Index >= 0) && (i_Index < Count))
			{
				Remove(MenuItems[i_Index].Item);
			}
		}
	}
}