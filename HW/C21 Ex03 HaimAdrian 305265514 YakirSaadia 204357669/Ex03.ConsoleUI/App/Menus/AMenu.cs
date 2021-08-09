using System;
using Ex03.ConsoleUI.App.Menus.Model;
using Ex03.ConsoleUI.App.Utils;
using Ex03.GarageLogic.Api.Utils;
using Ex03.UserInputUtils;

namespace Ex03.ConsoleUI.App.Menus
{
	internal abstract class AMenu<TMenuItem>
	{
		private readonly MenuItemGroup<TMenuItem> r_MenuItemGroup;
		private readonly ConsoleMenuManager<TMenuItem> r_ConsoleMenuManager;

		protected AMenu()
		{
			r_MenuItemGroup = new MenuItemGroup<TMenuItem>();

			// ReSharper disable once VirtualMemberCallInConstructor
			r_ConsoleMenuManager = new ConsoleMenuManager<TMenuItem>(MenuTitle, r_MenuItemGroup);

			// ReSharper disable once VirtualMemberCallInConstructor
			InitMenuItems();
		}

		protected static string ReadLicenseNumberForActions()
		{
			return ConsoleReader.ReadUserInputWithValidation("Please enter license number: ", FormatValidations.IsAlphaNumeric);
		}

		protected static bool HandleErrorAndAskForRetry(string i_ErrorMessage, Exception i_Exception)
		{
			Console.WriteLine("{0}{1}{2}Would you like to try again? (Y/N)", i_ErrorMessage, i_Exception.Message, Environment.NewLine);
			string userInput = ConsoleReader.ReadUserInputWithValidation(string.Empty, IsInputValidFunc);

			return eKeys.Y.ToString().Equals(userInput, StringComparison.InvariantCultureIgnoreCase);
		}

		protected static bool IsInputValidFunc(string i_InputString)
		{
			return eKeys.Y.ToString().Equals(i_InputString, StringComparison.InvariantCultureIgnoreCase) ||
				   eKeys.N.ToString().Equals(i_InputString, StringComparison.InvariantCultureIgnoreCase);
		}

		protected MenuItemGroup<TMenuItem> MenuItemGroup
		{
			get
			{
				return r_MenuItemGroup;
			}
		}

		protected abstract string MenuTitle { get; }

		protected abstract void InitMenuItems();

		protected void AddExitMenuItem(string i_Text)
		{
			r_ConsoleMenuManager.ExitMenu = i_Text;
		}

		protected TMenuItem Show(bool i_ClearConsole)
		{
			return r_ConsoleMenuManager.Show(i_ClearConsole);
		}

		public virtual TMenuItem Show()
		{
			const bool v_ClearConsole = true;
			return Show(v_ClearConsole);
		}
	}
}