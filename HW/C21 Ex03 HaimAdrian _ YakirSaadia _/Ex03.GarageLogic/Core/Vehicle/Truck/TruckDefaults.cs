using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Vehicle.Truck
{
	internal static class TruckDefaults
	{
		private const int k_NumberOfTires = 16;

		private const float k_MaxTireAirPressure = 26;

		private const float k_MaxFuelLiters = 110;

		private const eFuelType k_FuelType = eFuelType.Soler;

		public static int NumberOfTires
		{
			get
			{
				return k_NumberOfTires;
			}
		}

		public static float MaxTireAirPressure
		{
			get
			{
				return k_MaxTireAirPressure;
			}
		}

		public static float MaxFuelLiters
		{
			get
			{
				return k_MaxFuelLiters;
			}
		}

		public static eFuelType FuelType
		{
			get
			{
				return k_FuelType;
			}
		}
	}
}
