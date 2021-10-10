using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Vehicle.Car
{
	internal static class CarDefaults
	{
		private const int k_NumberOfTires = 4;

		private const float k_MaxTireAirPressure = 30;

		private const float k_MaxBatteryTimeHours = 2.8F;

		private const float k_MaxFuelLiters = 50;

		private const eFuelType k_FuelType = eFuelType.Octan95;

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

		public static float MaxBatteryTimeHours
		{
			get
			{
				return k_MaxBatteryTimeHours;
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
