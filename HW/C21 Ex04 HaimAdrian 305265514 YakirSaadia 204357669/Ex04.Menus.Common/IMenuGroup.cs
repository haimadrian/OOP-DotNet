using System.Collections.Generic;

namespace Ex04.Menus.Common
{
    public interface IMenuGroup : IMenuItem
	{
		IList<IMenuItem> Items { get; }
	}
}
