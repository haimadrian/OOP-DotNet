using System;
using Ex03.ConsoleUI.App.Menus.Model;
using Ex03.ConsoleUI.App.Utils;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Garage;

namespace Ex03.ConsoleUI.App.Menus
{
	internal class ListVehiclesLicenseNumberMenu : AMenu<int>
	{
		private static void onMenuItemChosen(MenuItem<int> i_Menuitem)
		{
			int userChoice = i_Menuitem.Item;
			Predicate<eVehicleState> filter = null;

			try
			{
				if (Enum.IsDefined(typeof(eVehicleState), userChoice))
				{
					eVehicleState stateToFilter = (eVehicleState)Enum.ToObject(typeof(eVehicleState), userChoice);
					filter = delegate(eVehicleState i_State) { return stateToFilter == i_State; };
				}
			}
			catch (Exception)
			{
				// ignored
			}

			Console.WriteLine("License numbers:{0}{1}", Environment.NewLine, CollectionUtils.ToString(GarageController.Instance.CollectLicenseNumbers(filter)));
		}

		protected override string MenuTitle
		{
			get
			{
				return "Vehicles Status Selection";
			}
		}

		protected override void InitMenuItems()
		{
			const string k_AllFilter = "All";

			Array vehicleStates = Enum.GetValues(typeof(eVehicleState));
			foreach (eVehicleState currentItem in vehicleStates)
			{
				MenuItemGroup.Add((int)currentItem, currentItem.ToString(), onMenuItemChosen);
			}

			MenuItemGroup.Add(vehicleStates.Length + 1, k_AllFilter, onMenuItemChosen);

			AddExitMenuItem("Go Back");
		}
	}
}
