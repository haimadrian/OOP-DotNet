using System;

namespace Ex03.GarageLogic.Api.Exceptions
{
	public class WrongVehicleTypeException : AVehicleWrongKindException
	{
		public WrongVehicleTypeException()
		{
		}

		public WrongVehicleTypeException(string i_Message, string i_VehicleLicenseNumber, string i_ExpectedKind, string i_ActualKind) : base(
			i_Message,
			i_VehicleLicenseNumber,
			i_ExpectedKind,
			i_ActualKind,
			null)
		{
		}

		public WrongVehicleTypeException(
			string i_Message,
			string i_VehicleLicenseNumber,
			string i_ExpectedKind,
			string i_ActualKind,
			Exception i_InnerException) : base(i_Message, i_VehicleLicenseNumber, i_ExpectedKind, i_ActualKind, i_InnerException)
		{
		}
	}
}
