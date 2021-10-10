using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Vehicle.Motorcycle
{
	internal static class MotorcycleDefaults
	{
		private const int k_NumberOfTires = 2;

		private const float k_MaxTireAirPressure = 28;

		private const float k_MaxBatteryTimeHours = 1.6F;

		private const float k_MaxFuelLiters = 5.5F;

		private const eFuelType k_FuelType = eFuelType.Octan98;

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
