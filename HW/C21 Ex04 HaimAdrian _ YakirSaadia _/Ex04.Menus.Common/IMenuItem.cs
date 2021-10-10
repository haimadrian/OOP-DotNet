namespace Ex04.Menus.Common
{
    public interface IMenuItem
    {
		string Caption { get; set; }

		bool IsReadOnly { get; set; }

		void OnMenuItemSelected();
	}
}
