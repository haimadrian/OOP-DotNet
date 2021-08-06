using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Core.Vehicle.Energy;

namespace Ex03.GarageLogic.Core.Vehicle
{
	internal abstract class AFuelVehicle : AVehicle<FuelEngine>, IFuelVehicle
	{
		protected AFuelVehicle(string i_Brand, string i_LicenseNumber) : base(i_Brand, i_LicenseNumber, new FuelEngine())
		{
		}

		public eFuelType FuelType
		{
			get
			{
				return Engine.FuelType;
			}

			set
			{
				Engine.FuelType = value;
			}
		}

		public float FuelLeftLiters
		{
			get
			{
				return Engine.EnergyLeft;
			}

			private set
			{
				Engine.EnergyLeft = value;
			}
		}

		public float FuelMaxLiters
		{
			get
			{
				return Engine.EnergyMax;
			}

			set
			{
				Engine.EnergyMax = value;
			}
		}

		public void Refuel(float i_FuelLitersToFill)
		{
			FuelLeftLiters += i_FuelLitersToFill;
		}

		public void DrainFuel(float i_FuelLitersToRemove)
		{
			Refuel(-i_FuelLitersToRemove);
		}

		public override string ToString()
		{
			return string.Format("{0}, FuelLeftLiters={1}, FuelMaxLiters={2}", base.ToString(), FuelLeftLiters, FuelMaxLiters);
		}
	}
}