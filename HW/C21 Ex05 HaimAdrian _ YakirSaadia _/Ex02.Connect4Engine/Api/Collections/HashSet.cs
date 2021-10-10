using System.Collections;
using System.Collections.Generic;

namespace Ex02.Connect4Engine.Api.Collections
{
	public class HashSet<T> : ICollection<T>
	{
		private readonly Dictionary<T, bool> r_BackedByDictionary;

		public HashSet()
		{
			r_BackedByDictionary = new Dictionary<T, bool>();
		}

		public HashSet(int i_Capacity)
		{
			r_BackedByDictionary = new Dictionary<T, bool>(i_Capacity);
		}

		private Dictionary<T, bool> BackedByDictionary
		{
			get
			{
				return r_BackedByDictionary;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return BackedByDictionary.Keys.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(T i_Item)
		{
			if (i_Item != null)
			{
				BackedByDictionary[i_Item] = true;
			}
		}

		public void Clear()
		{
			BackedByDictionary.Clear();
		}

		public bool Contains(T i_Item)
		{
			bool contains = false;

			if (i_Item != null)
			{
				contains = BackedByDictionary.ContainsKey(i_Item);
			}

			return contains;
		}

		public void CopyTo(T[] i_Array, int i_ArrayIndex)
		{
			BackedByDictionary.Keys.CopyTo(i_Array, i_ArrayIndex);
		}

		public bool Remove(T i_Item)
		{
			bool removed = false;

			if (i_Item != null)
			{
				removed = BackedByDictionary.Remove(i_Item);
			}

			return removed;
		}

		public int Count
		{
			get
			{
				return BackedByDictionary.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public override string ToString()
		{
			return BackedByDictionary.Keys.ToString();
		}
	}
}
