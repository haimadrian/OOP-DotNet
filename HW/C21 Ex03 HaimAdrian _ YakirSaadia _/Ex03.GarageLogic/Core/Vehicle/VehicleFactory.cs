using System;
using System.Reflection;
using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Vehicle
{
	internal static class VehicleFactory
	{
		public static T NewVehicle<T>(VehicleType i_VehicleType, string i_Brand, string i_LicenseNumber)
			where T : IVehicle
		{
			object[] args = { i_Brand, i_LicenseNumber };

			try
			{
				return (T)Activator.CreateInstance(i_VehicleType.Type, args);
			}
			catch (TargetInvocationException e)
			{
				// As a result of using reflection, we get TargetInvocationException when 
				// the constructor throws an exception from Logic layer. So we catch it and
				// rethrow as the Logic exception, skipping the reflection exception.
				if (e.InnerException != null)
				{
					throw e.InnerException;
				}

				throw;
			}
		}
	}
}