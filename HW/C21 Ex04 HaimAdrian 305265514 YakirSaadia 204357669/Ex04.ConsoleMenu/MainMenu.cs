using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Common;

namespace Ex04.ConsoleMenu
{
	/// <summary>
	/// A console implementation of a main menu.
	/// This class works with the common interfaces of menus, such that user can select what menu implementation to use.
	/// </summary>
	public class MainMenu
	{
		private const int k_IndexOfExit = 0;
		private const string k_MenuGroupSuffix = "\t>";

		private readonly IList<IMenuItem> r_RootGroup;

		private readonly string r_Title;

		private int m_CurrentLevelItemsCount;

		public MainMenu(string i_Title)
		{
			r_RootGroup = new List<IMenuItem>();
			r_Title = i_Title;

			const string k_ExitCaption = "Exit";
			ExitMenuItem exitMenuItem = new ExitMenuItem();
			exitMenuItem.Caption = k_ExitCaption;
			AddMenuItem(exitMenuItem);
		}

		public void AddMenuItem(IMenuItem i_MenuItem)
		{
			IMenuGroup item = i_MenuItem as IMenuGroup;
			if (item != null)
			{
				item.Caption += k_MenuGroupSuffix;
				addBackMenuItemRecursively(item.Items);
			}

			r_RootGroup.Add(i_MenuItem);
		}

		public void InsertMenuItem(int i_Index, IMenuItem i_MenuItem)
		{
			if (i_Index == k_IndexOfExit)
			{
				throw new ArgumentException(string.Format("Index {0} is reserved for Exit menu item", k_IndexOfExit));
			}

			r_RootGroup.Insert(i_Index, i_MenuItem);
		}

		public void Show()
		{
			show(r_Title, r_RootGroup);
		}

		private void addBackMenuItemRecursively(IList<IMenuItem> i_MenuItems)
		{
			foreach (IMenuItem currentItem in i_MenuItems)
			{
				IMenuGroup item = currentItem as IMenuGroup;
				if (item != null)
				{
					item.Caption += k_MenuGroupSuffix;
					addBackMenuItemRecursively(item.Items);
				}
			}

			const string k_BackCaption = "Back";
			ExitMenuItem backMenuItem = new ExitMenuItem();
			backMenuItem.Caption = k_BackCaption;
			i_MenuItems.Insert(k_IndexOfExit, backMenuItem);
		}

		private void show(string i_Title, IList<IMenuItem> i_MenuItems)
		{
			int userChoice;
			do
			{
				Console.Clear();
				printMenu(i_Title, i_MenuItems);

				m_CurrentLevelItemsCount = i_MenuItems.Count;
				string userInput = ConsoleReader.ReadUserInputWithValidation(string.Empty, isUserChoiceValid);
				userChoice = int.Parse(userInput);

				IMenuItem selectedMenuItem = i_MenuItems[userChoice];

				if (!selectedMenuItem.IsReadOnly)
				{
					selectedMenuItem.OnMenuItemSelected();
				}

				// In case of a group, dive in
				IMenuGroup selectedMenuGroup = selectedMenuItem as IMenuGroup;
				if (selectedMenuGroup != null)
				{
					show(selectedMenuGroup.Caption, selectedMenuGroup.Items);
				}
			}
			while (userChoice != k_IndexOfExit);
		}

		private void printMenu(string i_Title, IList<IMenuItem> i_MenuItems)
		{
			StringBuilder menu = new StringBuilder();

			if (!string.IsNullOrEmpty(i_Title))
			{
				menu.AppendLine(i_Title.Replace(k_MenuGroupSuffix, string.Empty)).AppendLine();
			}

			if ((i_MenuItems != null) && (i_MenuItems.Count > 0))
			{
				menu.AppendLine("Please select one of the choices below:");

				for (int currentMenuItemIndex = 1; currentMenuItemIndex < i_MenuItems.Count; currentMenuItemIndex++)
				{
					IMenuItem currentMenuItem = i_MenuItems[currentMenuItemIndex];
					menu.Append(currentMenuItemIndex).Append(". ").AppendLine(currentMenuItem.Caption);
				}

				menu.Append(k_IndexOfExit).Append(". ").AppendLine(i_MenuItems[k_IndexOfExit].Caption);
			}

			Console.WriteLine(menu.ToString());
		}

		private bool isUserChoiceValid(string i_InputString)
		{
			int choice;
			return !string.IsNullOrEmpty(i_InputString) &&
				   int.TryParse(i_InputString, out choice) &&
				   (choice >= k_IndexOfExit) &&
				   (choice < m_CurrentLevelItemsCount);
		}

		private class ExitMenuItem : AMenuItem
		{
			public ExitMenuItem()
			{
				IsReadOnly = true;
			}

			public override void OnMenuItemSelected()
			{
				// Back or Exit
				Console.WriteLine("{0}...", Caption);
			}
		}
	}
}
