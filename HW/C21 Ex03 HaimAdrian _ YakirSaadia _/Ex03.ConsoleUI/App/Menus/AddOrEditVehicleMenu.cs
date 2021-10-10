using System;
using System.Collections.Generic;
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
	internal class AddOrEditVehicleMenu : AExpandableMenu<eMenuItem>
	{
		private static void onEditVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			const bool v_IsPublicSetterOnly = true;
			doEditVehicle(v_IsPublicSetterOnly);
		}

		private static void onEditAdvancedVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			const bool v_IsPublicSetterOnly = true;
			doEditVehicle(!v_IsPublicSetterOnly);
		}

		private static void doEditVehicle(bool i_IsPublicSettersOnly)
		{
			DoBeforeMenu();
			Console.WriteLine("Edit Vehicle{0}{1}", i_IsPublicSettersOnly ? string.Empty : " (Advanced)", Environment.NewLine);

			bool tryAgain;
			do
			{
				try
				{
					string licenseNumber = ConsoleReader.ReadUserInputWithValidation("Please enter license number: ", FormatValidations.IsAlphaNumeric);
					IVehicle vehicle = GarageController.Instance.GetVehicle(licenseNumber);

					const bool v_ShowExistingValue = true;
					ReflectionUtils.FillInInstancePropertiesFromConsole(vehicle, i_IsPublicSettersOnly, v_ShowExistingValue);

					if (!i_IsPublicSettersOnly)
					{
						editTires(vehicle);
					}

					Console.WriteLine("Vehicle with license number {0} has been updated successfully.", licenseNumber);
					tryAgain = false;
				}
				catch (FormatException e)
				{
					tryAgain = HandleErrorAndAskForRetry("Wrong input. Reason: ", e);
				}
				catch (NoSuchVehicleException e)
				{
					tryAgain = HandleErrorAndAskForRetry(string.Empty, e);
				}
			}
			while (tryAgain);
		}

		private static void editTires(IVehicle i_Vehicle)
		{
			using(IEnumerator<Tire> tiresEnumerator = i_Vehicle.Tires.GetEnumerator())
			{
				const string k_AirPressurePropertyName = "AirPressure";
				const string k_MaxAirPressureFieldName = "r_MaxAirPressure";

				bool continueEdit = true;
				for (int tireIndex = 1; continueEdit && tiresEnumerator.MoveNext(); tireIndex++)
				{
					Tire currentTire = tiresEnumerator.Current;

					if (currentTire != null)
					{
						string userInputMessage = string.Format(
@"Tire #{0}: {1}
Please enter maximum air pressure, or negative or zero to stop editing: ",
							tireIndex,
							currentTire);
						string userInput = ConsoleReader.ReadUserInputWithValidation(userInputMessage, isFloat);
						float maxAirPressure = float.Parse(userInput);

						if (maxAirPressure <= 0)
						{
							continueEdit = false;
						}
						else
						{
							try
							{
								FieldInfo field = currentTire.GetType().GetField(k_MaxAirPressureFieldName, BindingFlags.Instance | BindingFlags.NonPublic);

								// ReSharper disable once PossibleNullReferenceException
								field.SetValue(currentTire, maxAirPressure);

								userInputMessage = "Please enter air pressure, or out of range to stop editing: ";
								userInput = ConsoleReader.ReadUserInputWithValidation(userInputMessage, isFloat);
								float airPressure = float.Parse(userInput);

								PropertyInfo property = currentTire.GetType().GetProperty(k_AirPressurePropertyName);

								// ReSharper disable once PossibleNullReferenceException
								property.GetSetMethod(true).Invoke(currentTire, new object[] { airPressure });
							}
							catch (Exception)
							{
								continueEdit = false;
							}
						}
					}
				}
			}
		}

		private static bool isFloat(string i_UserInput)
		{
			float ignore;
			return !string.IsNullOrEmpty(i_UserInput) && float.TryParse(i_UserInput, out ignore);
		}

		protected override string MenuTitle
		{
			get
			{
				return "Add/Edit Vehicle";
			}
		}

		protected override void InitMenuItems()
		{
			MenuItemGroup.Add(eMenuItem.AddVehicle, "Add new vehicle", onAddVehicleMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.EditVehicle, "Edit existing vehicle", onEditVehicleMenuItemChosen);
			MenuItemGroup.Add(eMenuItem.EditVehicleAdvanced, "Advanced edit existing vehicle (Including tires)", onEditAdvancedVehicleMenuItemChosen);
			AddExitMenuItem("Go Back to Main Menu");
		}

		private void onAddVehicleMenuItemChosen(MenuItem<eMenuItem> i_MenuItem)
		{
			DoBeforeMenu();

			try
			{
				ComputeExpandedMenuIfMissing<AddVehicleMenu>(i_MenuItem.Item).Show();
			}
			catch (ExitMenuException)
			{
				// Continue
			}
		}
	}
}