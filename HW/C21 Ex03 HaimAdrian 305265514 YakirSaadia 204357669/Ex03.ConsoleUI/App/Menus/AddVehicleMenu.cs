using System;
using System.Reflection;
using Ex03.ConsoleUI.App.Menus.Model;
using Ex03.ConsoleUI.App.Reflection;
using Ex03.ConsoleUI.App.Utils;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Exceptions;
using Ex03.GarageLogic.Api.Utils;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.UserInputUtils;

namespace Ex03.ConsoleUI.App.Menus
{
	internal class AddVehicleMenu : AMenu<VehicleType>
	{
		private const string k_Title = "Add Vehicle";

		protected override string MenuTitle
		{
			get
			{
				return k_Title;
			}
		}

		protected override void InitMenuItems()
		{
			PropertyInfo[] vehicleTypes = typeof(VehicleType).GetProperties(BindingFlags.Public | BindingFlags.Static);

			foreach (PropertyInfo currentProperty in vehicleTypes)
			{
				if (currentProperty.CanRead && (currentProperty.PropertyType == typeof(VehicleType)))
				{
					MenuItemGroup.Add((VehicleType)currentProperty.GetValue(null, null), currentProperty.Name, onMenuItemChosen);
				}
			}
		}

		private void onMenuItemChosen(MenuItem<VehicleType> i_Menuitem)
		{
			bool tryAgain;
			do
			{
				try
				{
					string ownerName = ConsoleReader.ReadUserInputWithValidation("Please enter owner name: ", FormatValidations.IsAlphabetic);
					string ownerPhone = ConsoleReader.ReadUserInputWithValidation("Please enter owner phone: ", FormatValidations.IsValidPhoneNumber);
					string brandName = ConsoleReader.ReadUserInputWithValidation("Please enter brand name: ", FormatValidations.IsAlphaNumeric);
					string licenseNumber = ConsoleReader.ReadUserInputWithValidation("Please enter license number: ", FormatValidations.IsAlphaNumeric);

					IVehicle vehicle = VehicleController.Instance.NewVehicle<IVehicle>(i_Menuitem.Item, brandName, licenseNumber);
					ReflectionUtils.FillInPublicInstancePropertiesFromConsole(vehicle);

					GarageController.Instance.AddVehicle(GarageController.Instance.GetOrCreateCustomer(ownerName, ownerPhone), vehicle);
					tryAgain = false;
				}
				catch (FormatException e)
				{
					tryAgain = HandleErrorAndAskForRetry("Wrong input. Reason: ", e);
				}
				catch (VehicleAlreadyExistsException e)
				{
					tryAgain = HandleErrorAndAskForRetry(string.Empty, e);
				}
			}
			while (tryAgain);
		}
	}
}