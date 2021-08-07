using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Api.Vehicle.Car;
using Ex03.GarageLogic.Api.Vehicle.Motorcycle;
using Ex03.GarageLogic.Api.Vehicle.Truck;

namespace Ex03.UnitTests
{
	internal static class TestUtils
	{
		public static IElectricMotorcycle CreateElectricMotorcycle(string i_LicenseNumber)
		{
			IElectricMotorcycle electricMotorcycle =
				VehicleController.Instance.NewVehicle<IElectricMotorcycle>(VehicleType.ElectricMotorcycle, "BB", i_LicenseNumber);
			electricMotorcycle.LicenseType = eLicenseType.A;
			electricMotorcycle.EngineCapacityCubicCentimeter = 500;
			electricMotorcycle.SetTiresManufacturerName("TB");
			return electricMotorcycle;
		}

		public static IElectricMotorcycle CreateElectricMotorcycle(string i_Brand, string i_LicenseNumber)
		{
			IElectricMotorcycle electricMotorcycle =
				VehicleController.Instance.NewVehicle<IElectricMotorcycle>(VehicleType.ElectricMotorcycle, i_Brand, i_LicenseNumber);
			electricMotorcycle.LicenseType = eLicenseType.A;
			electricMotorcycle.EngineCapacityCubicCentimeter = 500;
			electricMotorcycle.SetTiresManufacturerName("TB");
			return electricMotorcycle;
		}

		public static IElectricCar CreateElectricCar(string i_LicenseNumber)
		{
			IElectricCar electricCar = VehicleController.Instance.NewVehicle<IElectricCar>(VehicleType.ElectricCar, "BB", i_LicenseNumber);
			electricCar.Color = eColor.Yellow;
			electricCar.DoorsAmount = eDoorsAmount.Two;
			electricCar.SetTiresManufacturerName("TB");
			return electricCar;
		}

		public static IFuelTruck CreateFuelTruck(string i_LicenseNumber)
		{
			IFuelTruck fuelTruck = VehicleController.Instance.NewVehicle<IFuelTruck>(VehicleType.FuelTruck, "BB", i_LicenseNumber);
			fuelTruck.HavingDangerousSubstances = true;
			fuelTruck.CargoVolume = 600;
			fuelTruck.SetTiresManufacturerName("TB");
			return fuelTruck;
		}
	}
}
