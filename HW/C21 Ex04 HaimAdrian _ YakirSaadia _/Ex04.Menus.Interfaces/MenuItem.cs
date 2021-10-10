using Ex04.Menus.Common;
using Ex04.Menus.Interfaces.Observer;

namespace Ex04.Menus.Interfaces
{
	public class MenuItem : AMenuItem
	{
		private Observable<IMenuItem> m_MenuItemSelected;

		public Observable<IMenuItem> MenuItemSelected
		{
			get
			{
				if (m_MenuItemSelected == null)
				{
					m_MenuItemSelected = new Observable<IMenuItem>();
				}

				return m_MenuItemSelected;
			}

			// ReSharper disable once ValueParameterNotUsed
			set
			{
				// Exposed in order to support += operator of Observable. We ignore the value set.
			}
		}

		public override void OnMenuItemSelected()
		{
			MenuItemSelected.NotifyObservers(this);
		}
	}
}
