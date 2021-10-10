using System;

namespace Ex03.GarageLogic.Api.Exceptions
{
	public class NoSuchVehicleException : VehicleException
	{
		public NoSuchVehicleException()
		{
		}

		public NoSuchVehicleException(string i_Message, string i_VehicleLicenseNumber) : base(i_Message, i_VehicleLicenseNumber)
		{
		}

		public NoSuchVehicleException(string i_Message, string i_VehicleLicenseNumber, Exception i_InnerException) : base(
			i_Message,
			i_VehicleLicenseNumber,
			i_InnerException)
		{
		}
	}
}