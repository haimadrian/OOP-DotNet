﻿namespace Ex03.GarageLogic.Api.Vehicle
{
	public interface IFuelVehicle : IVehicle
	{
		eFuelType FuelType { get; set; }

		float FuelLeftLiters { get; }
		
		float FuelMaxLiters { get; set; }

		void Refuel(float i_FuelLitersToFill);

		void DrainFuel(float i_FuelLitersToRemove);
	}
}
