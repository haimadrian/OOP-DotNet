using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Api.Vehicle.Car;
using Ex03.GarageLogic.Api.Vehicle.Motorcycle;
using Ex03.GarageLogic.Api.Vehicle.Truck;

namespace Ex03.GarageLogic.Core.Vehicle.Visitors
{
	internal class VehicleToReportVisitor : IVehicleVisitor<string>
	{
		private const float k_MaxPercentageInToString = 100;

		private const string k_Yes = "Yes";

		private const string k_No = "No";

		private static string visitIElectricVehicle(IElectricVehicle i_Vehicle)
		{
			return string.Format("Battery Time (Hours, Left / Max): {0} / {1}", i_Vehicle.BatteryTimeLeftHours, i_Vehicle.BatteryTimeMaxHours);
		}

		private static string visitIFuelVehicle(IFuelVehicle i_Vehicle)
		{
			return string.Format("Fuel Amount (Liters, Left / Max): {0} / {1}", i_Vehicle.FuelLeftLiters, i_Vehicle.FuelMaxLiters);
		}

		private static string visitICarVehicle(ICar i_Vehicle)
		{
			return string.Format(
@"Color: {0}
Number of Doors: {1}",
				i_Vehicle.Color.ToString(),
				i_Vehicle.DoorsAmount.ToString());
		}

		private static string visitIMotorcycleVehicle(IMotorcycle i_Vehicle)
		{
			return string.Format(
@"License Type: {0}
Engine Capacity (Cubic Centimeter): {1}",
				i_Vehicle.LicenseType.ToString(),
				i_Vehicle.EngineCapacityCubicCentimeter);
		}

		private static string visitITruckVehicle(ITruck i_Vehicle)
		{
			return string.Format(
@"Cargo Volume: {0}
Having Dangerous Substances?: {1}",
				i_Vehicle.CargoVolume,
				i_Vehicle.HavingDangerousSubstances ? k_Yes : k_No);
		}

		private static string tiresToString(ICollection<Tire> i_Tires, string i_ElementSeparator)
		{
			StringBuilder tires = new StringBuilder();

			foreach (Tire currentTire in i_Tires)
			{
				tires.Append(currentTire).Append(i_ElementSeparator);
			}

			if (i_Tires.Count > 0)
			{
				tires.Remove(tires.Length - i_ElementSeparator.Length, i_ElementSeparator.Length);
			}

			return tires.ToString();
		}

		public string Visit(IElectricCar i_Vehicle)
		{
			return string.Format(
				"{1}{0}{2}{0}{3}",
				Environment.NewLine,
				Visit((IVehicle)i_Vehicle),
				visitIElectricVehicle(i_Vehicle),
				visitICarVehicle(i_Vehicle));
		}

		public string Visit(IFuelCar i_Vehicle)
		{
			return string.Format("{1}{0}{2}{0}{3}", Environment.NewLine, Visit((IVehicle)i_Vehicle), visitIFuelVehicle(i_Vehicle), visitICarVehicle(i_Vehicle));
		}

		public string Visit(IElectricMotorcycle i_Vehicle)
		{
			return string.Format(
				"{1}{0}{2}{0}{3}",
				Environment.NewLine,
				Visit((IVehicle)i_Vehicle),
				visitIElectricVehicle(i_Vehicle),
				visitIMotorcycleVehicle(i_Vehicle));
		}

		public string Visit(IFuelMotorcycle i_Vehicle)
		{
			return string.Format(
				"{1}{0}{2}{0}{3}",
				Environment.NewLine,
				Visit((IVehicle)i_Vehicle),
				visitIFuelVehicle(i_Vehicle),
				visitIMotorcycleVehicle(i_Vehicle));
		}

		public string Visit(IFuelTruck i_Vehicle)
		{
			return string.Format(
				"{1}{0}{2}{0}{3}",
				Environment.NewLine,
				Visit((IVehicle)i_Vehicle),
				visitIFuelVehicle(i_Vehicle),
				visitITruckVehicle(i_Vehicle));
		}

		public string Visit(IVehicle i_Vehicle)
		{
			return string.Format(
@"{0}
Brand: {1}
License Number: {2}
Energy Left (Percentage): {3}%
Tires: ({4})
	{5}",
				i_Vehicle.GetType().Name,
				i_Vehicle.Brand,
				i_Vehicle.LicenseNumber,
				i_Vehicle.EnergyLeftPercentage * k_MaxPercentageInToString,
				i_Vehicle.Tires.Count,
				tiresToString(i_Vehicle.Tires, Environment.NewLine + "\t"));
		}
	}
}