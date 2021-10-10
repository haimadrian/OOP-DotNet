using System;
using Ex03.ConsoleUI.App.Menus.Model;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Exceptions;
using Ex03.GarageLogic.Api.Garage;

namespace Ex03.ConsoleUI.App.Menus
{
	internal class UpdateVehicleGarageStateMenu : AMenu<eVehicleState>
	{
		private static void onMenuItemChosen(MenuItem<eVehicleState> i_Menuitem)
		{
			eVehicleState userChoice = i_Menuitem.Item;

			bool tryAgain;
			do
			{
				try
				{
					string licenseNumber = ReadLicenseNumberForActions();
					GarageController.Instance.UpdateVehicleState(licenseNumber, userChoice);

					Console.WriteLine("State of vehicle with license number {0} has been updated successfully.", licenseNumber);
					tryAgain = false;
				}
				catch (NoSuchVehicleException e)
				{
					tryAgain = HandleErrorAndAskForRetry("Wrong input. Reason: ", e);
				}
			}
			while (tryAgain);
		}

		protected override string MenuTitle
		{
			get
			{
				return string.Empty;
			}
		}

		public override eVehicleState Show()
		{
			Console.WriteLine("{0}{1}", "Update Vehicle Garage State", Environment.NewLine);

			const bool v_ClearConsole = true;
			return Show(!v_ClearConsole);
		}

		protected override void InitMenuItems()
		{
			Array vehicleStates = Enum.GetValues(typeof(eVehicleState));
			foreach (eVehicleState currentItem in vehicleStates)
			{
				MenuItemGroup.Add(currentItem, currentItem.ToString(), onMenuItemChosen);
			}

			AddExitMenuItem("Go Back");
		}
	}
}