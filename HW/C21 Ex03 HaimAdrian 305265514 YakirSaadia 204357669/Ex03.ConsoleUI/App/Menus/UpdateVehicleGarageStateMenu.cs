using System;
using Ex03.ConsoleUI.App.Menus.Model;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Exceptions;
using Ex03.GarageLogic.Api.Garage;

namespace Ex03.ConsoleUI.App.Menus
{
	internal class UpdateVehicleGarageStateMenu : AMenu<eVehicleState>
	{
		private const string k_Title = "Update Vehicle Garage State";

		private string m_LicenseNumber;

		protected override string MenuTitle
		{
			get
			{
				return string.Empty;
			}
		}

		public override eVehicleState Show()
		{
			Console.WriteLine("{0}{1}", k_Title, Environment.NewLine);

			m_LicenseNumber = ReadLicenseNumberForActions();

			Console.WriteLine();

			const bool v_ClearConsole = false;
			return Show(v_ClearConsole);
		}

		protected override void InitMenuItems()
		{
			Array vehicleStates = Enum.GetValues(typeof(eVehicleState));
			foreach (eVehicleState currentItem in vehicleStates)
			{
				MenuItemGroup.Add(currentItem, currentItem.ToString(), onMenuItemChosen);
			}
		}

		private void onMenuItemChosen(MenuItem<eVehicleState> i_Menuitem)
		{
			eVehicleState userChoice = i_Menuitem.Item;

			bool tryAgain;
			do
			{
				try
				{
					GarageController.Instance.UpdateVehicleState(m_LicenseNumber, userChoice);
					tryAgain = false;
				}
				catch (NoSuchVehicleException e)
				{
					tryAgain = HandleErrorAndAskForRetry("Wrong input. Reason: ", e);
				}
			}
			while (tryAgain);
		}
	}
}