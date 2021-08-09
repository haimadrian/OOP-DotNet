using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Api.Exceptions;
using Ex03.GarageLogic.Api.Garage;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Core.Vehicle.Visitors;

namespace Ex03.GarageLogic.Core.Garage
{
	internal class GarageImpl : IGarage
	{
		private readonly IDictionary<string, GarageVehicle> r_VehicleLicenseNumberToVehicle;

		public GarageImpl()
		{
			r_VehicleLicenseNumberToVehicle = new Dictionary<string, GarageVehicle>();
		}

		public IGarageVehicle this[string i_VehicleLicenseNumber]
		{
			get
			{
				if (!r_VehicleLicenseNumberToVehicle.ContainsKey(i_VehicleLicenseNumber))
				{
					throw new NoSuchVehicleException(
						string.Format("Vehicle with license number {0} is not in garage.", i_VehicleLicenseNumber),
						i_VehicleLicenseNumber);
				}

				return r_VehicleLicenseNumberToVehicle[i_VehicleLicenseNumber];
			}

			set
			{
				bool isAlreadyExisting = r_VehicleLicenseNumberToVehicle.ContainsKey(i_VehicleLicenseNumber);
				r_VehicleLicenseNumberToVehicle[i_VehicleLicenseNumber] = value as GarageVehicle;
				r_VehicleLicenseNumberToVehicle[i_VehicleLicenseNumber].VehicleState = eVehicleState.Repairing;

				if (isAlreadyExisting)
				{
					throw new VehicleAlreadyExistsException(
						string.Format("Vehicle with license number {0} already exists.", i_VehicleLicenseNumber),
						i_VehicleLicenseNumber);
				}
			}
		}

		public ICustomer GetOrCreateCustomer(string i_Name, string i_Phone)
		{
			return new Customer(i_Name, i_Phone);
		}

		public void AddVehicle(ICustomer i_Owner, IVehicle i_Vehicle)
		{
			this[i_Vehicle.LicenseNumber] = new GarageVehicle(i_Owner, i_Vehicle);
		}

		public bool ContainsVehicle(string i_LicenseNumber)
		{
			return r_VehicleLicenseNumberToVehicle.ContainsKey(i_LicenseNumber);
		}

		public IVehicle GetVehicle(string i_LicenseNumber)
		{
			return GetVehicle<IVehicle>(i_LicenseNumber);
		}

		public TVehicleType GetVehicle<TVehicleType>(string i_LicenseNumber)
			where TVehicleType : IVehicle
		{
			// Exception might be thrown by this[i_LicenseNumber] if vehicle does not exist
			return (TVehicleType)(this[i_LicenseNumber] as GarageVehicle).Vehicle;
		}

		public ICollection<string> CollectLicenseNumbers(Predicate<eVehicleState> i_Filter)
		{
			ICollection<string> licenseNumbers = new LinkedList<string>();

			// ReSharper disable once MoreSpecificForeachVariableTypeAvailable
			foreach (IGarageVehicle currentVehicle in r_VehicleLicenseNumberToVehicle.Values)
			{
				if ((i_Filter == null) || i_Filter.Invoke(currentVehicle.VehicleState))
				{
					licenseNumbers.Add(currentVehicle.Vehicle.LicenseNumber);
				}
			}

			return licenseNumbers;
		}

		public ICollection<IGarageVehicle> CollectVehicles(Predicate<IGarageVehicle> i_Filter)
		{
			ICollection<IGarageVehicle> garageVehicles = new LinkedList<IGarageVehicle>();

			// ReSharper disable once MoreSpecificForeachVariableTypeAvailable
			foreach (IGarageVehicle currentVehicle in r_VehicleLicenseNumberToVehicle.Values)
			{
				if ((i_Filter == null) || i_Filter.Invoke(currentVehicle))
				{
					garageVehicles.Add(currentVehicle);
				}
			}

			return garageVehicles;
		}

		public void UpdateVehicleState(string i_LicenseNumber, eVehicleState i_NewState)
		{
			// Exception might be thrown by this[i_LicenseNumber] if vehicle does not exist
			GarageVehicle vehicle = this[i_LicenseNumber] as GarageVehicle;

			if (vehicle != null)
			{
				vehicle.VehicleState = i_NewState;
			}
		}

		public void FullyInflateTiresOfVehicle(string i_LicenseNumber)
		{
			// Exception might be thrown by this[i_LicenseNumber] if vehicle does not exist
			foreach (Tire currentTire in this[i_LicenseNumber].Vehicle.Tires)
			{
				// Zero will do nothing
				currentTire.Inflate(currentTire.MaxAirPressure - currentTire.AirPressure);
			}
		}

		public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelLitersToFill)
		{
			IFuelVehicle vehicle = getValidatedVehicleType<IFuelVehicle>(i_LicenseNumber);

			if (vehicle.FuelType != i_FuelType)
			{
				string expectedType = vehicle.FuelType.ToString();
				string actualType = i_FuelType.ToString();
				throw new WrongFuelTypeException(
					string.Format("Wrong fuel type. Expected: {0}, Actual: {1}", expectedType, actualType),
					i_LicenseNumber,
					expectedType,
					actualType);
			}

			vehicle.Refuel(i_FuelLitersToFill);
		}

		public void RechargeVehicle(string i_LicenseNumber, float i_BatteryTimeToFillMinutes)
		{
			const float k_MinutesInHour = 60;
			IElectricVehicle vehicle = getValidatedVehicleType<IElectricVehicle>(i_LicenseNumber);
			vehicle.Charge(i_BatteryTimeToFillMinutes / k_MinutesInHour);
		}

		public string GetVehicleReport(string i_LicenseNumber)
		{
			IGarageVehicle garageVehicle = this[i_LicenseNumber];
			string vehicleReport = garageVehicle.Vehicle.Accept(new VehicleToReportVisitor());

			return string.Format(
@"Vehicle Status: {0}
Owner Details
	Name: {1}
	Phone: {2}
{3}",
				garageVehicle.VehicleState.ToString(),
				garageVehicle.Owner.Name,
				garageVehicle.Owner.Phone,
				vehicleReport.Replace(Environment.NewLine, Environment.NewLine + "\t"));
		}

		private TVehicleType getValidatedVehicleType<TVehicleType>(string i_LicenseNumber)
			where TVehicleType : class
		{
			TVehicleType vehicle = this[i_LicenseNumber].Vehicle as TVehicleType;

			if (vehicle == null)
			{
				string expectedType = typeof(TVehicleType).Name;
				string actualType = this[i_LicenseNumber].Vehicle.GetType().Name;
				throw new WrongVehicleTypeException(
					string.Format("Wrong vehicle type. Expected: {0}, Actual: {1}", expectedType, actualType),
					i_LicenseNumber,
					expectedType,
					actualType);
			}

			return vehicle;
		}
	}
}