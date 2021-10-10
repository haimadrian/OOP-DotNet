using System;
using System.Collections.Generic;
using Ex03.ConsoleUI.App.Menus.Model;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Exceptions;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.UserInputUtils;

namespace Ex03.ConsoleUI.App.Menus
{
	internal class MainMenu : AExpandableMenu<eMenuItem>
	{
		private static bool isFloatInput(string i_InputString)
		{
			float ignore;
			return !string.IsNullOrEmpty(i_InputString) && float.TryParse(i_InputString, out ignore);
		}

		private static int percentageScaleFrom1To100(float i_Percentage)
		{
			const int k_PercentTo100 = 100;
			return (int)(i_Percentage * k_PercentTo100);
		}

		protected override string MenuTitle
		{
			get
			{
				return "Welcome to Garage Application";
			}
		}

		protected override void InitMenuItems()
		{
			MenuItemGroup.Add(eMenuItem.AddOrEditVehicle, "Add/Edit vehicle", onAddVehicleMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.ListVehicleLicenseNumbers, "List vehicle license numbers", onListVehicleLicenseNumbersMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.UpdateVehicleGarageState, "Update vehicle status", onUpdateVehicleGarageStateMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.FullyInflateVehicleTires, "Fully inflate all vehicle tires", onFullyInflateVehicleTiresMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.RefuelVehicle, "Refuel fuel vehicle", onRefuelVehicleMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.RechargeVehicle, "Recharge electric vehicle", onRechargeVehicleMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.PrintVehicleReport, "Print vehicle report", onPrintVehicleReportMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.PrintAllVehicleReport, "Print all vehicles report", onPrintAllVehicleReportMenuItemChosen);
			AddExitMenuItem("Exit");
		}

		public override eMenuItem Show()
		{
			eMenuItem selectedMenuItem;
			const bool v_IsRunning = true;

			try
			{
				while (v_IsRunning)
				{
					base.Show();
				}
			}
			catch (ExitMenuException)
			{
				selectedMenuItem = default(eMenuItem);
			}

			return selectedMenuItem;
		}

		private void onAddVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			DoBeforeMenu();

			try
			{
				ComputeExpandedMenuIfMissing<AddOrEditVehicleMenu>(i_MenuItem.Item).Show();
				DoAfterMenu();
			}
			catch (ExitMenuException)
			{
				// Continue
			}
		}

		private void onListVehicleLicenseNumbersMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			DoBeforeMenu();

			try
			{
				ComputeExpandedMenuIfMissing<ListVehiclesLicenseNumberMenu>(i_MenuItem.Item).Show();
				DoAfterMenu();
			}
			catch (ExitMenuException)
			{
				// Continue
			}
		}

		private void onUpdateVehicleGarageStateMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			DoBeforeMenu();

			try
			{
				ComputeExpandedMenuIfMissing<UpdateVehicleGarageStateMenu>(i_MenuItem.Item).Show();
				DoAfterMenu();
			}
			catch (ExitMenuException)
			{
				// Continue
			}
		}

		private void onFullyInflateVehicleTiresMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			DoBeforeMenu();

			bool tryAgain;
			do
			{
				try
				{
					string licenseNumber = ReadLicenseNumberForActions();
					GarageController.Instance.FullyInflateTiresOfVehicle(licenseNumber);

					Console.WriteLine("All tires of vehicle with license number {0} are fully inflated.", licenseNumber);
					tryAgain = false;
				}
				catch (NoSuchVehicleException e)
				{
					tryAgain = HandleErrorAndAskForRetry("Wrong input. Reason: ", e);
				}
			}
			while (tryAgain);

			DoAfterMenu();
		}

		private void onRefuelVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			DoBeforeMenu();

			bool tryAgain;
			do
			{
				try
				{
					string licenseNumber = ReadLicenseNumberForActions();
					eFuelType selectedFuelType = (eFuelType)ConsoleReader.ReadEnumInputWithValidation("Please select fuel type: ", typeof(eFuelType));

					string userInput = ConsoleReader.ReadUserInputWithValidation("Please enter amount of liters to fill: ", isFloatInput);

					GarageController.Instance.RefuelVehicle(licenseNumber, selectedFuelType, float.Parse(userInput));

					IVehicle vehicle = GarageController.Instance.GetVehicle(licenseNumber);
					Console.WriteLine(
						"Vehicle with license number {0} has been refueled successfully. Tank capacity percentage: {1}%",
						licenseNumber,
						percentageScaleFrom1To100(vehicle.EnergyLeftPercentage));
					tryAgain = false;
				}
				catch (Exception e)
				{
					tryAgain = HandleErrorAndAskForRetry("Failed to refuel vehicle. Reason: ", e);
				}
			}
			while (tryAgain);

			DoAfterMenu();
		}

		private void onRechargeVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			DoBeforeMenu();

			bool tryAgain;
			do
			{
				try
				{
					string licenseNumber = ReadLicenseNumberForActions();

					string userInput = ConsoleReader.ReadUserInputWithValidation("Please enter how many minutes to fill: ", isFloatInput);

					GarageController.Instance.RechargeVehicle(licenseNumber, float.Parse(userInput));

					IVehicle vehicle = GarageController.Instance.GetVehicle(licenseNumber);
					Console.WriteLine(
						"Vehicle with license number {0} has been recharged successfully. Battery percentage: {1}%",
						licenseNumber,
						percentageScaleFrom1To100(vehicle.EnergyLeftPercentage));
					tryAgain = false;
				}
				catch (Exception e)
				{
					tryAgain = HandleErrorAndAskForRetry("Failed to refuel vehicle. Reason: ", e);
				}
			}
			while (tryAgain);

			DoAfterMenu();
		}

		private void onPrintVehicleReportMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			DoBeforeMenu();

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

			DoAfterMenu();
		}

		private void onPrintAllVehicleReportMenuItemChosen(MenuItem<eMenuItem> i_Menuitem)
		{
			DoBeforeMenu();

			ICollection<string> allLicenseNumbers = GarageController.Instance.CollectLicenseNumbers(null);

			foreach (string currentLicenseNumber in allLicenseNumbers)
			{
				Console.WriteLine("{0}{1}", GarageController.Instance.GetVehicleReport(currentLicenseNumber), Environment.NewLine);
			}

			DoAfterMenu();
		}
	}
}
