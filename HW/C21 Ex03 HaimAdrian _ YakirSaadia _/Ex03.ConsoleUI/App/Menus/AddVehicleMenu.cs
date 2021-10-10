using System;
using System.Reflection;
using Ex03.ConsoleUI.App.Menus.Model;
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
		private static void onMenuItemChosen(MenuItem<VehicleType> i_MenuItem)
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

					IVehicle vehicle = VehicleController.Instance.NewVehicle<IVehicle>(i_MenuItem.Item, brandName, licenseNumber);

					// Add the vehicle before reading properties for that vehicle, cause if vehicle already exists, it
					// is super annoying to fail at the very end of the process.. Hence, we would like to fail before.
					GarageController.Instance.AddVehicle(GarageController.Instance.GetOrCreateCustomer(ownerName, ownerPhone), vehicle);

					// We get here only when vehicle is new, for sure, so continue reading properties for that vehicle.
					ReflectionUtils.FillInPublicInstancePropertiesFromConsole(vehicle);

					Console.WriteLine("Vehicle with license number {0} has been added successfully.", licenseNumber);
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

		protected override string MenuTitle
		{
			get
			{
				return "Add Vehicle";
			}
		}

		protected override void InitMenuItems()
		{
			PropertyInfo[] vehicleTypes = typeof(VehicleType).GetProperties(BindingFlags.Public | BindingFlags.Static);

			foreach (PropertyInfo currentProperty in vehicleTypes)
			{
				if (currentProperty.CanRead && (currentProperty.PropertyType == typeof(VehicleType)))
				{
					MenuItemGroup.Add(
						(VehicleType)currentProperty.GetValue(null, null),
						ReflectionUtils.GetMemberDisplayName(currentProperty),
						onMenuItemChosen);
				}
			}

			AddExitMenuItem("Go Back to Main Menu");
		}
	}
}
