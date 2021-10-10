using System;

namespace Ex03.GarageLogic.Api.Exceptions
{
	public abstract class AVehicleWrongKindException : VehicleException
	{
		private readonly string r_ExpectedKind;

		private readonly string r_ActualKind;

		protected AVehicleWrongKindException() : this(string.Empty, null, null, null)
		{
		}

		protected AVehicleWrongKindException(string i_Message, string i_VehicleLicenseNumber, string i_ExpectedKind, string i_ActualKind) : this(
			i_Message,
			i_VehicleLicenseNumber,
			i_ExpectedKind,
			i_ActualKind,
			null)
		{
		}

		protected AVehicleWrongKindException(
			string i_Message,
			string i_VehicleLicenseNumber,
			string i_ExpectedKind,
			string i_ActualKind,
			Exception i_InnerException) : base(i_Message, i_VehicleLicenseNumber, i_InnerException)
		{
			r_ExpectedKind = i_ExpectedKind;
			r_ActualKind = i_ActualKind;
		}

		public string ExpectedKind
		{
			get
			{
				return r_ExpectedKind;
			}
		}

		public string ActualKind
		{
			get
			{
				return r_ActualKind;
			}
		}
	}
}
