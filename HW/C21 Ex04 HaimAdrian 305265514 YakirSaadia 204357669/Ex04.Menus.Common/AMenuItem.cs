namespace Ex04.Menus.Common
{
	public abstract class AMenuItem : IMenuItem
	{
		private string m_Caption;

		private bool m_IsReadOnly;

		public string Caption
		{
			get
			{
				return m_Caption;
			}

			set
			{
				m_Caption = value;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return m_IsReadOnly;
			}

			set
			{
				m_IsReadOnly = value;
			}
		}

		public abstract void OnMenuItemSelected();
	}
}