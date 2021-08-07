using System;
using System.Collections.Generic;
using System.Text;
using Ex03.ConsoleUI.App.Menus.Model;
using Ex03.ConsoleUI.App.Utils;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Exceptions;
using Ex03.GarageLogic.Api.Garage;
using Ex03.GarageLogic.Api.Utils;
using Ex03.UserInputUtils;

namespace Ex03.ConsoleUI.App.Menus
{
	internal class MainMenu : AMenu<eMenuItem>
	{
		private const string k_WelcomeMessage = "Welcome to Garage Application";

		private const int k_MinChoice = 1;

		private static void doBeforeMenu()
		{
			Console.Clear();
		}

		private static void doAfterMenu()
		{
			Console.WriteLine("{0}Press Enter to go back to main menu...", Environment.NewLine);
			Console.ReadLine();
		}

		private static string readLicenseNumberForActions()
		{
			return ConsoleReader.ReadUserInputWithValidation("Please enter license number: ", FormatValidations.IsAlphaNumeric);
		}

		private static bool isValidVehicleStatus(string i_InputString)
		{
			int maxChoice = Enum.GetValues(typeof(eVehicleState)).Length + 1;
			int choice;
			return !string.IsNullOrEmpty(i_InputString) && int.TryParse(i_InputString, out choice) && (choice >= k_MinChoice) && (choice <= maxChoice);
		}

		protected override string MenuTitle
		{
			get
			{
				return k_WelcomeMessage;
			}
		}

		protected override void InitMenuItems()
		{
			MenuItemGroup.Add(eMenuItem.AddVehicle, "Add vehicle", onAddVehicleMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.ListVehicleLicenseNumbers, "List vehicle license numbers", onListVehicleLicenseNumbersMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.UpdateVehicleGarageState, "Update vehicle status", onUpdateVehicleGarageStateMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.FullyInflateVehicleTires, "Fully inflate all vehicle tires", onFullyInflateVehicleTiresMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.RefuelVehicle, "Refuel fuel vehicle", onRefuelVehicleMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.RechargeVehicle, "Recharge electric vehicle", onRechargeVehicleMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.PrintVehicleReport, "Print vehicle report", onPrintVehicleReportMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.PrintAllVehicleReport, "Print all vehicles report", onPrintAllVehicleReportMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.Exit, null, null);
		}

		public eMenuItem Show()
		{
			eMenuItem selectedMenuItem;
			const bool v_ClearConsole = true;

			do
			{
				selectedMenuItem = Show(v_ClearConsole);
			}
			while (selectedMenuItem != eMenuItem.Exit);

			return selectedMenuItem;
		}

		private void onAddVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			doBeforeMenu();

			new AddVehicleMenu().Show();

			doAfterMenu();
		}

		private void onListVehicleLicenseNumbersMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			doBeforeMenu();

			StringBuilder inputMessage = new StringBuilder("Please select vehicle status:").AppendLine();
			Array statuses = Enum.GetValues(typeof(eVehicleState));

			foreach (eVehicleState currentStatus in statuses)
			{
				inputMessage.Append((int)currentStatus).Append(". ").AppendLine(currentStatus.ToString());
			}

			inputMessage.Append(statuses.Length + 1).AppendLine(". All");

			string userInput = ConsoleReader.ReadUserInputWithValidation(inputMessage.ToString(), isValidVehicleStatus);
			int userChoice = int.Parse(userInput);
			Predicate<eVehicleState> filter = null;

			if (userChoice <= statuses.Length)
			{
				eVehicleState stateToFilter = (eVehicleState)Enum.ToObject(typeof(eVehicleState), userChoice);
				filter = delegate(eVehicleState i_State) { return stateToFilter == i_State; };
			}

			Console.WriteLine("License numbers:{1}{2}", Environment.NewLine, CollectionUtils.ToString(GarageController.Instance.CollectLicenseNumbers(filter)));

			doAfterMenu();
		}

		private void onUpdateVehicleGarageStateMenuItemChosen(MenuItem<eMenuItem> i_Menuitem)
		{
			doBeforeMenu();

			doAfterMenu();
		}

		private void onFullyInflateVehicleTiresMenuItemChosen(MenuItem<eMenuItem> i_Menuitem)
		{
			doBeforeMenu();

			doAfterMenu();
		}

		private void onRefuelVehicleMenuItemChosen(MenuItem<eMenuItem> i_Menuitem)
		{
			doBeforeMenu();

			doAfterMenu();
		}

		private void onRechargeVehicleMenuItemChosen(MenuItem<eMenuItem> i_Menuitem)
		{
			doBeforeMenu();

			doAfterMenu();
		}

		private void onPrintVehicleReportMenuItemChosen(MenuItem<eMenuItem> i_Menuitem)
		{
			doBeforeMenu();

			string licenseNumber = readLicenseNumberForActions();

			try
			{
				Console.WriteLine(GarageController.Instance.GetVehicleReport(licenseNumber));
			}
			catch (NoSuchVehicleException e)
			{
				Console.WriteLine("Failed to print vehicle report. Reason: {0}", e.Message);
			}

			doAfterMenu();
		}

		private void onPrintAllVehicleReportMenuItemChosen(MenuItem<eMenuItem> i_Menuitem)
		{
			doBeforeMenu();

			ICollection<string> allLicenseNumbers = GarageController.Instance.CollectLicenseNumbers(null);

			foreach (string currentLicenseNumber in allLicenseNumbers)
			{
				Console.WriteLine("{0}{1}", GarageController.Instance.GetVehicleReport(currentLicenseNumber), Environment.NewLine);
			}

			doAfterMenu();
		}
	}
}