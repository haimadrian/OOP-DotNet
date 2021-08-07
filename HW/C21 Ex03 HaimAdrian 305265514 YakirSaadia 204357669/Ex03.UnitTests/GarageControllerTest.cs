using System;
using NUnit.Framework;
using Ex03.GarageLogic.Api.Controllers;
using Ex03.GarageLogic.Api.Exceptions;
using Ex03.GarageLogic.Api.Garage;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Api.Vehicle.Car;
using Ex03.GarageLogic.Api.Vehicle.Motorcycle;
using Ex03.GarageLogic.Api.Vehicle.Truck;

namespace Ex03.UnitTests
{
	[TestFixture]
	public class GarageControllerTest
	{
		[Test]
		public void TestMotorReport_AddNewElectricMotorToGarage_SeeReportForThatMotor()
		{
			// Arrange
			ICustomer owner = GarageController.Instance.GetOrCreateCustomer("Haim", "050-1234321");
			string licenseNumber = "111-111-111";
			IElectricMotorcycle electricMotorcycle = TestUtils.CreateElectricMotorcycle(licenseNumber);
			GarageController.Instance.AddVehicle(owner, electricMotorcycle);

			string expectedReport = @"Vehicle Status: Repairing
Owner Details
	Name: Haim
	Phone: 050-1234321
ElectricMotorcycle
	Brand: BB
	License Number: 111-111-111
	Energy Left (Percentage): 50%
	Tires: (2)
		Manufacturer: TB, Air Pressure (Actual / Max): 28 / 28
		Manufacturer: TB, Air Pressure (Actual / Max): 28 / 28
	Battery Time (Hours, Left / Max): 0.8 / 1.6
	License Type: A
	Engine Capacity (Cubic Centimeter): 500";

			// Act
			string vehicleReport = GarageController.Instance.GetVehicleReport(licenseNumber);

			// Assert
			Assert.AreEqual(expectedReport, vehicleReport, "Wrong report format");
		}

		[Test]
		public void TestCarReport_AddNewElectricCarToGarage_SeeReportForThatCar()
		{
			// Arrange
			ICustomer owner = GarageController.Instance.GetOrCreateCustomer("Haim", "050-1234321");
			string licenseNumber = "111-111-112";
			IElectricCar electricCar = TestUtils.CreateElectricCar(licenseNumber);
			GarageController.Instance.AddVehicle(owner, electricCar);

			string expectedReport = @"Vehicle Status: Repairing
Owner Details
	Name: Haim
	Phone: 050-1234321
ElectricCar
	Brand: BB
	License Number: 111-111-112
	Energy Left (Percentage): 50%
	Tires: (4)
		Manufacturer: TB, Air Pressure (Actual / Max): 30 / 30
		Manufacturer: TB, Air Pressure (Actual / Max): 30 / 30
		Manufacturer: TB, Air Pressure (Actual / Max): 30 / 30
		Manufacturer: TB, Air Pressure (Actual / Max): 30 / 30
	Battery Time (Hours, Left / Max): 1.4 / 2.8
	Color: Yellow
	Number of Doors: Two";

			// Act
			string vehicleReport = GarageController.Instance.GetVehicleReport(licenseNumber);

			// Assert
			Assert.AreEqual(expectedReport, vehicleReport, "Wrong report format");
		}

		[Test]
		public void TestTruckReport_AddNewFuelTruckToGarage_SeeReportForThatTruck()
		{
			// Arrange
			ICustomer owner = GarageController.Instance.GetOrCreateCustomer("Haim", "050-1234321");
			string licenseNumber = "111-111-113";
			IFuelTruck fuelTruck = TestUtils.CreateFuelTruck(licenseNumber);
			GarageController.Instance.AddVehicle(owner, fuelTruck);

			string expectedReport = @"Vehicle Status: Repairing
Owner Details
	Name: Haim
	Phone: 050-1234321
FuelTruck
	Brand: BB
	License Number: 111-111-113
	Energy Left (Percentage): 50%
	Tires: (16)
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
		Manufacturer: TB, Air Pressure (Actual / Max): 26 / 26
	Fuel Amount (Liters, Left / Max): 55 / 110
	Cargo Volume: 600
	Having Dangerous Substances?: Yes";

			// Act
			string vehicleReport = GarageController.Instance.GetVehicleReport(licenseNumber);

			// Assert
			Assert.AreEqual(expectedReport, vehicleReport, "Wrong report format");
		}

		[Test]
		public void TestMotorReAdd_AddNewElectricMotorToGarageTwice_CatchExceptionAndSeeVehicleStateModified()
		{
			// Arrange
			ICustomer owner = GarageController.Instance.GetOrCreateCustomer("Haim", "050-1234321");
			string licenseNumber = "111-111-114";
			IElectricMotorcycle electricMotorcycle = TestUtils.CreateElectricMotorcycle(licenseNumber);
			GarageController.Instance.AddVehicle(owner, electricMotorcycle);

			GarageController.Instance.UpdateVehicleState(licenseNumber, eVehicleState.Paid);
			string vehicleReportBefore = GarageController.Instance.GetVehicleReport(licenseNumber);

			// Act
			Exception e = null;
			try
			{
				GarageController.Instance.AddVehicle(owner, electricMotorcycle);
			}
			catch (VehicleAlreadyExistsException exception)
			{
				e = exception;
			}

			string vehicleReportAfter = GarageController.Instance.GetVehicleReport(licenseNumber);

			// Assert
			Assert.True(vehicleReportBefore.Contains("Vehicle Status: Paid"), "UpdateVehicleState did not work");
			Assert.NotNull(e, "We are supposed to receive VehicleAlreadyExistsException when adding an existing vehicle");
			Assert.True(vehicleReportAfter.Contains("Vehicle Status: Repairing"), "Vehicle state should be modified to Repairing when adding it");
		}

		[Test]
		public void TestMotorChargeAndInflate_ChargeDrainedElectricBatteryAndInflateTires_Success()
		{
			// Arrange
			ICustomer owner = GarageController.Instance.GetOrCreateCustomer("Haim", "050-1234321");
			string licenseNumber = "111-111-115";
			IElectricMotorcycle electricMotorcycle = TestUtils.CreateElectricMotorcycle(licenseNumber);
			GarageController.Instance.AddVehicle(owner, electricMotorcycle);

			float batteryBefore = electricMotorcycle.BatteryTimeLeftHours;
			electricMotorcycle.Discharge(0.2F);

			Random random = new Random();
			foreach (Tire currentTire in electricMotorcycle.Tires)
			{
				currentTire.Deflate(random.Next((int)currentTire.MaxAirPressure));
			}

			// Act
			Exception e = null;
			try
			{
				float batteryTimeToFillMinutes = (electricMotorcycle.BatteryTimeMaxHours + 1) * 60;
				GarageController.Instance.RechargeVehicle(licenseNumber, batteryTimeToFillMinutes);
			}
			catch (ValueOutOfRangeException exception)
			{
				e = exception;
			}

			const float v_BatteryTimeToFillMinutes = 0.2F * 60;
			GarageController.Instance.RechargeVehicle(licenseNumber, v_BatteryTimeToFillMinutes);
			GarageController.Instance.FullyInflateTiresOfVehicle(licenseNumber);

			// Assert
			Assert.NotNull(e, "We are supposed to receive ValueOutOfRangeException when charging more than maximum");
			Assert.AreEqual(batteryBefore, electricMotorcycle.BatteryTimeLeftHours, "Charging of vehicle did not work");
			foreach (Tire currentTire in electricMotorcycle.Tires)
			{
				Assert.AreEqual(currentTire.MaxAirPressure, currentTire.AirPressure, "Inflate vehicle tires to maximum did not work");
			}
		}
	}
}