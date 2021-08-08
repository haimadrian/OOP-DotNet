using System;
using System.Collections.Generic;
using Ex03.ConsoleUI.App.Menus.Model;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Exceptions;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.UserInputUtils;

namespace Ex03.ConsoleUI.App.Menus
{
	internal class MainMenu : AMenu<eMenuItem>
	{
		private const string k_WelcomeMessage = "Welcome to Garage Application";

		private static readonly IDictionary<eMenuItem, object> sr_ExpandedMenus;

		static MainMenu()
		{
			sr_ExpandedMenus = new Dictionary<eMenuItem, object>();
		}

		private static void doBeforeMenu()
		{
			Console.Clear();
		}

		private static void doAfterMenu()
		{
			Console.WriteLine("{0}Press Enter to go back to main menu...", Environment.NewLine);
			Console.ReadLine();
		}

		private static TMenuType computeExpandedMenuIfMissing<TMenuType>(eMenuItem i_MenuItem)
		{
			if (!sr_ExpandedMenus.ContainsKey(i_MenuItem))
			{
				sr_ExpandedMenus[i_MenuItem] = Activator.CreateInstance(typeof(TMenuType));
			}

			return (TMenuType)sr_ExpandedMenus[i_MenuItem];
		}

		private static void onAddVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			doBeforeMenu();

			computeExpandedMenuIfMissing<AddVehicleMenu>(i_MenuItem.Item).Show();

			doAfterMenu();
		}

		private static void onListVehicleLicenseNumbersMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			doBeforeMenu();

			computeExpandedMenuIfMissing<ListVehiclesLicenseNumberMenu>(i_MenuItem.Item).Show();

			doAfterMenu();
		}

		private static void onUpdateVehicleGarageStateMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			doBeforeMenu();

			computeExpandedMenuIfMissing<UpdateVehicleGarageStateMenu>(i_MenuItem.Item).Show();

			doAfterMenu();
		}

		private static void onFullyInflateVehicleTiresMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			doBeforeMenu();

			bool tryAgain;
			do
			{
				try
				{
					string licenseNumber = ReadLicenseNumberForActions();
					GarageController.Instance.FullyInflateTiresOfVehicle(licenseNumber);
					tryAgain = false;
				}
				catch (NoSuchVehicleException e)
				{
					tryAgain = HandleErrorAndAskForRetry("Wrong input. Reason: ", e);
				}
			}
			while (tryAgain);

			doAfterMenu();
		}

		private static void onRefuelVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			doBeforeMenu();

			bool tryAgain;
			do
			{
				try
				{
					string licenseNumber = ReadLicenseNumberForActions();
					eFuelType selectedFuelType = (eFuelType)ConsoleReader.ReadEnumInputWithValidation("Please select fuel type: ", typeof(eFuelType));

					string userInput = ConsoleReader.ReadUserInputWithValidation("Please enter amount of liters to fill: ", isFloatInput);

					GarageController.Instance.RefuelVehicle(licenseNumber, selectedFuelType, float.Parse(userInput));
					tryAgain = false;
				}
				catch (Exception e)
				{
					tryAgain = HandleErrorAndAskForRetry("Failed to refuel vehicle. Reason: ", e);
				}
			}
			while (tryAgain);

			doAfterMenu();
		}

		private static void onRechargeVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			doBeforeMenu();

			bool tryAgain;
			do
			{
				try
				{
					string licenseNumber = ReadLicenseNumberForActions();

					string userInput = ConsoleReader.ReadUserInputWithValidation("Please enter how many minutes to fill: ", isFloatInput);

					GarageController.Instance.RechargeVehicle(licenseNumber, float.Parse(userInput));
					tryAgain = false;
				}
				catch (Exception e)
				{
					tryAgain = HandleErrorAndAskForRetry("Failed to refuel vehicle. Reason: ", e);
				}
			}
			while (tryAgain);

			doAfterMenu();
		}

		private static void onPrintVehicleReportMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			doBeforeMenu();

			bool tryAgain;
			do
			{
				try
				{
					string licenseNumber = ReadLicenseNumberForActions();
					Console.WriteLine(GarageController.Instance.GetVehicleReport(licenseNumber));
					tryAgain = false;
				}
				catch (NoSuchVehicleException e)
				{
					tryAgain = HandleErrorAndAskForRetry("Failed to print vehicle report. Reason: ", e);
				}
			}
			while (tryAgain);

			doAfterMenu();
		}

		private static void onPrintAllVehicleReportMenuItemChosen(MenuItem<eMenuItem> i_Menuitem)
		{
			doBeforeMenu();

			ICollection<string> allLicenseNumbers = GarageController.Instance.CollectLicenseNumbers(null);

			foreach (string currentLicenseNumber in allLicenseNumbers)
			{
				Console.WriteLine("{0}{1}", GarageController.Instance.GetVehicleReport(currentLicenseNumber), Environment.NewLine);
			}

			doAfterMenu();
		}

		private static bool isFloatInput(string i_InputString)
		{
			float ignore;
			return !string.IsNullOrEmpty(i_InputString) && float.TryParse(i_InputString, out ignore);
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

		public override eMenuItem Show()
		{
			eMenuItem selectedMenuItem;

			do
			{
				selectedMenuItem = base.Show();
			}
			while (selectedMenuItem != eMenuItem.Exit);

			return selectedMenuItem;
		}
	}
}