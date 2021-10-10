using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Api.Garage;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Core.Garage;

namespace Ex03.GarageLogic.Api.Controllers
{
	public sealed class GarageController : IGarage
	{
		private static readonly GarageController sr_Instance = new GarageController();

		private readonly GarageImpl r_Garage;

		private GarageController()
		{
			r_Garage = new GarageImpl();
		}

		public static GarageController Instance
		{
			get
			{
				return sr_Instance;
			}
		}

		private GarageImpl Garage
		{
			get
			{
				return r_Garage;
			}
		}

		public ICustomer GetOrCreateCustomer(string i_Name, string i_Phone)
		{
			return Garage.GetOrCreateCustomer(i_Name, i_Phone);
		}

		public void AddVehicle(ICustomer i_Owner, IVehicle i_Vehicle)
		{
			Garage.AddVehicle(i_Owner, i_Vehicle);
		}

		public IVehicle GetVehicle(string i_LicenseNumber)
		{
			return Garage.GetVehicle(i_LicenseNumber);
		}

		public TVehicleType GetVehicle<TVehicleType>(string i_LicenseNumber)
			where TVehicleType : IVehicle
		{
			return Garage.GetVehicle<TVehicleType>(i_LicenseNumber);
		}

		public bool ContainsVehicle(string i_LicenseNumber)
		{
			return Garage.ContainsVehicle(i_LicenseNumber);
		}

		public ICollection<string> CollectLicenseNumbers(Predicate<eVehicleState> i_Filter)
		{
			return Garage.CollectLicenseNumbers(i_Filter);
		}

		public void UpdateVehicleState(string i_LicenseNumber, eVehicleState i_NewState)
		{
			Garage.UpdateVehicleState(i_LicenseNumber, i_NewState);
		}

		public void FullyInflateTiresOfVehicle(string i_LicenseNumber)
		{
			Garage.FullyInflateTiresOfVehicle(i_LicenseNumber);
		}

		public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelLitersToFill)
		{
			Garage.RefuelVehicle(i_LicenseNumber, i_FuelType, i_FuelLitersToFill);
		}

		public void RechargeVehicle(string i_LicenseNumber, float i_BatteryTimeToFillMinutes)
		{
			Garage.RechargeVehicle(i_LicenseNumber, i_BatteryTimeToFillMinutes);
		}

		public string GetVehicleReport(string i_LicenseNumber)
		{
			return Garage.GetVehicleReport(i_LicenseNumber);
		}
	}
}
