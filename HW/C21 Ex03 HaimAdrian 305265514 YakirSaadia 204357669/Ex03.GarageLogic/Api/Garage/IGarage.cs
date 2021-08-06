using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Api.Garage
{
	public interface IGarage
	{
		void AddVehicle(string i_OwnerName, string i_OwnerPhone, IVehicle i_Vehicle);

		bool ContainsVehicle(string i_LicenseNumber);

		ICollection<string> CollectLicenseNumbers(Predicate<eVehicleState> i_Filter);

		void UpdateVehicleState(string i_LicenseNumber, eVehicleState i_NewState);

		void FullyInflateTiresOfVehicle(string i_LicenseNumber);

		void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelLitersToFill);

		void RechargeVehicle(string i_LicenseNumber, float i_BatteryTimeToFillMinutes);

		string GetVehicleReport(string i_LicenseNumber);
	}
}