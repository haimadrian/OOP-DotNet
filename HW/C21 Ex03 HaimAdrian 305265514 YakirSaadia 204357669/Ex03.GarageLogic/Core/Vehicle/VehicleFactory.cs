using System;
using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Vehicle
{
	internal static class VehicleFactory
	{
		public static T NewVehicle<T>(VehicleType i_VehicleType, string i_Brand, string i_LicenseNumber)
			where T : IVehicle
		{
			object[] args = { i_Brand, i_LicenseNumber };

			return (T)Activator.CreateInstance(i_VehicleType.Type, args);
		}
	}
}