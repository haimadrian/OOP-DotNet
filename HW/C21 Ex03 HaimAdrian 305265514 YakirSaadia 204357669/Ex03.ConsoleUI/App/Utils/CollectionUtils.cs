using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI.App.Utils
{
	public class CollectionUtils
	{
		private const string k_CollectionPrefix = "[";

		private const string k_CollectionSuffix = "]";

		private const string k_CollectionSeparator = ", ";

		public static string ToString<T>(ICollection<T> i_Collection)
		{
			StringBuilder collectionAsString = new StringBuilder(k_CollectionPrefix);

			foreach (T item in i_Collection)
			{
				collectionAsString.Append(item).Append(k_CollectionSeparator);
			}

			if (i_Collection.Count > 0)
			{
				collectionAsString.Remove(collectionAsString.Length - k_CollectionSeparator.Length, k_CollectionSeparator.Length);
			}

			collectionAsString.Append(k_CollectionSuffix);

			return collectionAsString.ToString();
		}
	}
}