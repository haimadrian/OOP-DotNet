﻿namespace Ex03.GarageLogic.Api.Vehicle
{
	public interface IElectricVehicle : IVehicle
	{
		float BatteryTimeMaxHours { get; set; }

		float BatteryTimeLeftHours { get; }

		void Charge(float i_BatteryTimeToFillHours);

		void Discharge(float i_BatteryTimeToRemove);
	}
}
