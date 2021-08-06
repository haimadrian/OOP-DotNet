using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Api.Vehicle.Car;
using Ex03.GarageLogic.Api.Vehicle.Motorcycle;
using Ex03.GarageLogic.Api.Vehicle.Truck;

namespace Ex03.ConsoleUI.App
{
	internal class GarageApplication
	{
		private const string k_CollectionPrefix = "[";
		private const string k_CollectionSuffix = "]";
		private const string k_CollectionSeparator = ", ";

		public GarageApplication(bool i_IsHavingDummyData)
		{
			if (i_IsHavingDummyData)
			{
				createDummyData();
			}
		}

		private static string collectionToString<T>(ICollection<T> i_Collection)
		{
			StringBuilder collectionAsString = new StringBuilder(k_CollectionPrefix);

			foreach (T item in i_Collection)
			{
				collectionAsString.Append(item).Append(k_CollectionSeparator);
			}

			if (i_Collection.Count > 0)
			{
				collectionAsString.Remove(collectionAsString.Length - k_CollectionSeparator.Length, k_CollectionSeparator.Length);
			}

			collectionAsString.Append(k_CollectionSuffix);

			return collectionAsString.ToString();
		}

		private void createDummyData()
		{
			IElectricMotorcycle electricMotorcycle =
				VehicleController.Instance.NewVehicle<IElectricMotorcycle>(VehicleType.ElectricMotorcycle, "ZB", "111-111-111");
			electricMotorcycle.LicenseType = eLicenseType.A;
			electricMotorcycle.EngineCapacityCubicCentimeter = 500;
			electricMotorcycle.SetTiresManufacturerName("Zubi");
			GarageController.Instance.AddVehicle("Haim", "050-1114444", electricMotorcycle);

			IFuelMotorcycle fuelMotorcycle =
				VehicleController.Instance.NewVehicle<IFuelMotorcycle>(VehicleType.FuelMotorcycle, "ZB", "111-111-112");
			fuelMotorcycle.LicenseType = eLicenseType.A1;
			fuelMotorcycle.EngineCapacityCubicCentimeter = 250;
			fuelMotorcycle.SetTiresManufacturerName("Zubi");
			GarageController.Instance.AddVehicle("Haim", "050-1114444", fuelMotorcycle);

			IElectricCar electricCar =
				VehicleController.Instance.NewVehicle<IElectricCar>(VehicleType.ElectricCar, "ZB", "111-111-113");
			electricCar.Color = eColor.Yellow;
			electricCar.DoorsAmount = eDoorsAmount.Two;
			electricCar.SetTiresManufacturerName("Back");
			GarageController.Instance.AddVehicle("Haim", "050-1114444", electricCar);

			IFuelTruck fuelTruck =
				VehicleController.Instance.NewVehicle<IFuelTruck>(VehicleType.FuelTruck, "ZB", "111-111-114");
			fuelTruck.HavingDangerousSubstances = true;
			fuelTruck.CargoVolume = 600;
			fuelTruck.SetTiresManufacturerName("SMK");
			GarageController.Instance.AddVehicle("Him", "050-1114444", fuelTruck);
		}

		public void Run()
		{
			ICollection<string> collectLicenseNumbers = GarageController.Instance.CollectLicenseNumbers(null);
			Console.WriteLine("{0}{1}", collectionToString(collectLicenseNumbers), Environment.NewLine);

			foreach (string currentLicenseNumber in collectLicenseNumbers)
			{
				Console.WriteLine("{0}{1}", GarageController.Instance.GetVehicleReport(currentLicenseNumber), Environment.NewLine);
			}
		}
	}
}
