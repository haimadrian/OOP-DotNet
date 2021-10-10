using System;

namespace Ex03.GarageLogic.Api.Exceptions
{
	public class VehicleException : Exception
	{
		private readonly string r_VehicleLicenseNumber;

		public VehicleException() : this(string.Empty, null, null)
		{
		}

		public VehicleException(string i_Message, string i_VehicleLicenseNumber) : this(i_Message, i_VehicleLicenseNumber, null)
		{
		}

		public VehicleException(string i_Message, string i_VehicleLicenseNumber, Exception i_InnerException) : base(i_Message, i_InnerException)
		{
			r_VehicleLicenseNumber = i_VehicleLicenseNumber;
		}

		public string VehicleLicenseNumber
		{
			get
			{
				return r_VehicleLicenseNumber;
			}
		}
	}
}